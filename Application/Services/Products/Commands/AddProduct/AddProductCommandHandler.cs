using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public AddProductCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.ProductName))
                return ResultDto.Fail("لطفا نام محصول را وارد کنید.");

            if (request.CategoryId == 0)
                return ResultDto.Fail("لطفا دسته‌بندی را انتخاب کنید.");

            if (request.CompanyId == 0)
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید.");

            if (_db.Products.Any(s => s.ProductName == request.ProductName))
                return ResultDto.Fail("نام وارد شده تکراری می‌باشد!");

            if (!_db.Categories.Any(c => c.CategoryId == request.CategoryId))
                return ResultDto.Fail("دسته‌بندی انتخاب‌شده وجود ندارد!");

            if (!_db.Companies.Any(c => c.CompanyId == request.CompanyId))
                return ResultDto.Fail("شرکت انتخاب‌شده وجود ندارد!");

            var machines = new List<Machine>();
            if (request.Machines != null && request.Machines.Any())
            {
                machines = await _db.Machines
                    .Where(w => request.Machines.Contains(w.MachineId))
                    .ToListAsync();

                if (request.Machines.Count != machines.Count)
                    return ResultDto.Fail("برخی از دستگاه‌های انتخاب‌شده یافت نشدند.");
            }

            var product = new Product
            {
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                CompanyId = request.CompanyId,
                Machines = machines
            };

            await _db.Products.AddAsync(product, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return ResultDto.Success("محصول با موفقیت افزوده شد.");
        }
    }
}

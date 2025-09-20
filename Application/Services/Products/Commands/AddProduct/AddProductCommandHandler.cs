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
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDto>
    {
        private readonly IDataBaseContext _db;
        public AddProductCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.ProductName))
                return new ProductDto { resultMessage= "لطفا نام محصول را وارد کنید." };

            if (request.CategoryId == 0)
                return new ProductDto { resultMessage= "لطفا دسته‌بندی را انتخاب کنید." };

            if (request.CompanyId == 0)
                return new ProductDto { resultMessage = "لطفا شرکت را انتخاب کنید." };

            if (_db.Products.Any(s => s.ProductName == request.ProductName))
                return new ProductDto { resultMessage = "نام وارد شده تکراری می‌باشد!" };

            if (!_db.Categories.Any(c => c.CategoryId == request.CategoryId))
                return new ProductDto { resultMessage = "دسته‌بندی انتخاب‌شده وجود ندارد!" };

            if (!_db.Companies.Any(c => c.CompanyId == request.CompanyId))
                return new ProductDto { resultMessage = "شرکت انتخاب‌شده وجود ندارد!" };

            var machines = new List<Machine>();
            if (request.Machines != null && request.Machines.Any())
            {
                machines = await _db.Machines
                    .Where(w => request.Machines.Contains(w.MachineId))
                    .ToListAsync();

                if (request.Machines.Count != machines.Count)
                    return new ProductDto { resultMessage = "برخی از دستگاه‌های انتخاب‌شده یافت نشدند." };
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
            var productdto = new ProductDto
            {
                resultMessage = "محصول با موفقیت افزوده شد.",
                CompanyId = request.CompanyId,
                CategoryId = request.CategoryId,
                ProductId = product.ProductId,
                ProductName = request.ProductName,
            };
            return productdto;  
            //return ResultDto.Success(, productDto: new ProductDto()
            //{
            //    CompanyId = product.CompanyId,
            //    CategoryId= product.CategoryId,
            //    ProductId = product.ProductId,
            //    ProductName = product.ProductName,
            //});
        }
    }
}

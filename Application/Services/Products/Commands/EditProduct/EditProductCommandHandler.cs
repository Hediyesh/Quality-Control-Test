using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;

        public EditProductCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = _db.Products
                .Include(p=> p.Machines)
                .FirstOrDefault(p => p.ProductId == request.ProductId);
            if (product == null)
                return ResultDto.Fail("محصول مورد نظر یافت نشد.");

            if (string.IsNullOrWhiteSpace(request.ProductName))
                return ResultDto.Fail("لطفاً نام محصول را وارد کنید.");

            if (request.CategoryId == 0)
                return ResultDto.Fail("لطفاً دسته‌بندی را انتخاب کنید.");

            if (request.CompanyId == 0)
                return ResultDto.Fail("لطفاً شرکت را انتخاب کنید.");

            if (_db.Products.Any(p => p.ProductName == request.ProductName && p.ProductId != request.ProductId))
                return ResultDto.Fail("نام محصول تکراری است.");

            if (!_db.Categories.Any(c => c.CategoryId == request.CategoryId))
                return ResultDto.Fail("دسته‌بندی انتخاب‌شده وجود ندارد.");

            if (!_db.Companies.Any(c => c.CompanyId == request.CompanyId))
                return ResultDto.Fail("شرکت انتخاب‌شده وجود ندارد.");
            var newMachineIds = request.Machines?.Distinct().ToList() ?? new List<int>();

            var validMachines = _db.Machines
                                   .Where(m => newMachineIds.Contains(m.MachineId))
                                   .ToList();

            if (validMachines.Count != newMachineIds.Count)
                return ResultDto.Fail("برخی از دستگاه‌های انتخاب‌شده یافت نشدند.");

            // --- بروزرسانی ماشین‌ها (حذف + اضافه) ---
            var currentMachineIds = product.Machines?.Select(m => m.MachineId).ToList();
            if (product.Machines != null)
            {
                // حذف دستگاه‌هایی که در لیست جدید نیستند
                foreach (var machine in product.Machines.ToList())
                {
                    if (!newMachineIds.Contains(machine.MachineId))
                    {
                        product.Machines.Remove(machine);
                    }
                }

            }

            // اضافه کردن دستگاه‌هایی که جدید هستند
            foreach (var machine in validMachines)
            {
                if (currentMachineIds != null)
                {
                    if (!currentMachineIds.Contains(machine.MachineId))
                    {
                        product.Machines?.Add(machine);
                    }
                }
            }
            //List<Machine> machines = new();
            //if (request.Machines != null && request.Machines.Any())
            //{
            //    machines = _db.Machines
            //        .Where(m => request.Machines.Contains(m.MachineId))
            //        .ToList();

            //    if (machines.Count != request.Machines.Count)
            //        return ResultDto.Fail("برخی از دستگاه‌های انتخاب‌شده یافت نشدند.");
            //}
            //product.Machines = machines;

            // اعمال تغییرات
            product.ProductName = request.ProductName;
            product.CategoryId = request.CategoryId;
            product.CompanyId = request.CompanyId;

            await _db.SaveChangesAsync(cancellationToken);

            return ResultDto.Success("محصول با موفقیت ویرایش شد.");
        }
    }
}

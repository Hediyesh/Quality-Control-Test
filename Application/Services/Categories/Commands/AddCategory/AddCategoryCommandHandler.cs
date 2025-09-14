using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using ControlService.ControlDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public AddCategoryCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CategoryName))
                return ResultDto.Fail("لطفا نام گروه را مشخص کنید");
            var company = await _db.Companies.Where(w => w.CompanyId == request.CompanyId).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید");
            var oldCat = await _db.Categories.Where(w=> w.CompanyId == request.CompanyId && w.CategoryName == request.CategoryName).FirstOrDefaultAsync();
            if (oldCat != null)
                return ResultDto.Fail("این گروه از قبل در این شرکت اضافه شده است");
            var cat = new Category()
            {
                CategoryName = request.CategoryName,
                CompanyId = request.CompanyId,
            };
            await _db.Categories.AddAsync(cat);
            await _db.SaveChangesAsync();
            return ResultDto.Success("اطلاعات با موفقیت ثبت شد");
        }
    }
}

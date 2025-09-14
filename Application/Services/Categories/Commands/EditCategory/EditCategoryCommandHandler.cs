using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public EditCategoryCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var cat = await _db.Categories.Where(w => w.CategoryId == request.Id).FirstOrDefaultAsync();
            if (cat == null)
                return ResultDto.Fail("چنین گروهی وجود ندارد");
            if (string.IsNullOrEmpty(request.CategoryName))
                return ResultDto.Fail("لطفا نام گروه را مشخص کنید");
            var company = await _db.Companies.Where(w => w.CompanyId == request.CompanyId).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید");
            var oldCat = await _db.Categories.Where(w => w.CompanyId == request.CompanyId &&
            w.CategoryName == request.CategoryName && w.CategoryId != request.Id).FirstOrDefaultAsync();
            if (oldCat != null)
                return ResultDto.Fail("این گروه از قبل در این شرکت اضافه شده است");
            cat.CategoryName = request.CategoryName;
            cat.CompanyId = request.CompanyId;
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت ویرایش شد");
        }
    }
}

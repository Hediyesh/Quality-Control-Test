using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Companies.Commands.EditCompany
{
    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public EditCompanyCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _db.Companies.Where(w => w.CompanyId == request.Id).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("چنین شرکتی وجود ندارد");
            if (string.IsNullOrEmpty(request.CompanyName))
                return ResultDto.Fail("لطفا نام شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.PhoneNumber))
                return ResultDto.Fail("لطفا شماره تلفن شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.Email))
                return ResultDto.Fail("لطفا ایمیل شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.Address))
                return ResultDto.Fail("لطفا آدرس شرکت را وارد کنید");
            var companyname = await _db.Companies.Where(w => w.CompanyName == request.CompanyName && w.CompanyId != request.Id).FirstOrDefaultAsync();
            if (companyname != null)
                return ResultDto.Fail("نام شرکت تکراری است");
            company.CompanyName = request.CompanyName;
            company.PhoneNumber = request.PhoneNumber;
            company.Email = request.Email;
            company.Address = request.Address;
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت ویرایش شد");
        }
    }
}

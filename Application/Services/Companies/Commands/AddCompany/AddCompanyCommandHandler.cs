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

namespace ControlApplication.Services.Companies.Commands.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public AddCompanyCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CompanyName))
                return ResultDto.Fail("لطفا نام شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.PhoneNumber))
                return ResultDto.Fail("لطفا شماره تلفن شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.Email))
                return ResultDto.Fail("لطفا ایمیل شرکت را وارد کنید");
            if (string.IsNullOrEmpty(request.Address))
                return ResultDto.Fail("لطفا آدرس شرکت را وارد کنید");
            var companyname = await _db.Companies.Where(w => w.CompanyName == request.CompanyName).FirstOrDefaultAsync();
            if (companyname != null)
                return ResultDto.Fail("نام شرکت تکراری است");
            var company = new Company()
            {
                Address = request.Address,
                CompanyName = request.CompanyName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };
            await _db.Companies.AddAsync(company);
            await _db.SaveChangesAsync();
            return ResultDto.Success("اطلاعات با موفقیت ثبت شد");
        }
    }
}

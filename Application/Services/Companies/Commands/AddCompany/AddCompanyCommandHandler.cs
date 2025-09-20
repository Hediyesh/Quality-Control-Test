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
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, CompanyDto>
    {
        private readonly IDataBaseContext _db;
        public AddCompanyCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<CompanyDto> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CompanyName))
                return new CompanyDto { resultMessage = "لطفا نام شرکت را وارد کنید" };
            if (string.IsNullOrEmpty(request.PhoneNumber))
                return new CompanyDto { resultMessage = "لطفا شماره تلفن شرکت را وارد کنید" };
            if (string.IsNullOrEmpty(request.Email))
                return new CompanyDto { resultMessage = "لطفا ایمیل شرکت را وارد کنید" };
            if (string.IsNullOrEmpty(request.Address))
                return new CompanyDto { resultMessage = "لطفا آدرس شرکت را وارد کنید" };
            var companyname = await _db.Companies.Where(w => w.CompanyName == request.CompanyName).FirstOrDefaultAsync();
            if (companyname != null)
                return new CompanyDto { resultMessage = "نام شرکت تکراری است" };
            var company = new Company()
            {
                Address = request.Address,
                CompanyName = request.CompanyName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };
            await _db.Companies.AddAsync(company);
            await _db.SaveChangesAsync();
            var companydto = new CompanyDto
            {
                resultMessage = "اطلاعات با موفقیت ثبت شد",
                CompanyName = request.CompanyName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Id = company.CompanyId,
            };
            return companydto;
            //return ResultDto.Success("", companyDto : new CompanyDto() { PhoneNumber = company.PhoneNumber,
            //Id = company.CompanyId, Address = company.Address, CompanyName = company.CompanyName, Email = company.Email});
        }
    }
}

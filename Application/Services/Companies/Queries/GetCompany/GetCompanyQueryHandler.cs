using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Companies.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IDataBaseContext _db;
        public GetCompanyQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = _db.Companies.Where(w => w.CompanyId == request.Id).FirstOrDefault();
            if (company == null)
                return Task.FromResult(new CompanyDto());
            return Task.FromResult(new CompanyDto()
            {
                Id = company.CompanyId,
                CompanyName = company.CompanyName,
                Address = company.Address,
                Email = company.Email,
                PhoneNumber = company.PhoneNumber,
            });
        }
    }
}

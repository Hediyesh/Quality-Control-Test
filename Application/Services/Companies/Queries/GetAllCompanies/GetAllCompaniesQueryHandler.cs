using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Companies.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler: IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllCompaniesQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = _db.Companies.Select(x=> new CompanyDto
            {
                Address = x.Address,
                Id = x.CompanyId,
                CompanyName = x.CompanyName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).OrderByDescending(x => x.Id).ToList();
            return Task.FromResult(companies);
        }
    }
}

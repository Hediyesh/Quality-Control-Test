using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.CompanyCategoriesMachines.GetCompanyCategoriesMachines
{
    public class GetCompanyCategoriesMachinesHandler : IRequestHandler<GetCompanyCategoriesMachinesQuery, GetCompanyCategoriesMachinesDto>
    {
        private readonly IDataBaseContext _db;
        public GetCompanyCategoriesMachinesHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<GetCompanyCategoriesMachinesDto> Handle(GetCompanyCategoriesMachinesQuery request, CancellationToken cancellationToken)
        {
            var company = _db.Companies.Where(w => w.CompanyId == request.companyId).FirstOrDefault();
            if (company == null)
            {
                throw new ArgumentException("شرکتی با این نام وجود ندارد!");
            }
            var categories = _db.Categories.Where(w=> w.CompanyId == company.CompanyId).ToList();
            var machines = _db.Machines.Where(w => w.CompanyId == company.CompanyId).ToList();
            return Task.FromResult(new GetCompanyCategoriesMachinesDto { CompanyId = company.CompanyId, 
                CompanyName = company.CompanyName, machines = machines, categories = categories});
        }
    }
}

using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetMLMachinesByCompany
{
    public class GetMLMachinesByCompanyHandler: IRequestHandler<GetMLMachinesByCompanyQuery, List<Machine>>
    {
        private readonly IDataBaseContext _db;
        public GetMLMachinesByCompanyHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<List<Machine>> Handle(GetMLMachinesByCompanyQuery request, CancellationToken cancellationToken)
        {
            var machines = _db.Machines.Where(w => w.CompanyId == request.companyId).ToList();
            return Task.FromResult(machines);
        }
    }
}

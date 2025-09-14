using ControlApplication.Services.Categories.Queries.GetAllCategories;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Queries.GetAllMachines
{
    public class GetAllMachinesQueryHandler : IRequestHandler<GetAllMachinesQuery, List<MachineDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllMachinesQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<List<MachineDto>> Handle(GetAllMachinesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Machines.Select(x => new MachineDto()
            {
                MachineName = x.MachineName,
                MachineId = x.MachineId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
            }).OrderByDescending(x => x.MachineId).ToList());
        }
    }
}

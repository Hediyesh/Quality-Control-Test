using ControlApplication.Services.Categories.Queries.GetCategory;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Queries.GetMachine
{
    public class GetMachineQueryHandler : IRequestHandler<GetMachineQuery, MachineDto>
    {
        private readonly IDataBaseContext _db;
        public GetMachineQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<MachineDto> Handle(GetMachineQuery request, CancellationToken cancellationToken)
        {
            var machine = _db.Machines.Where(w => w.MachineId == request.Id).Select(x => new MachineDto()
            {
                MachineId = x.MachineId,
                MachineName = x.MachineName,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
            }).FirstOrDefault();
            if (machine == null)
                return Task.FromResult(new MachineDto());
            return Task.FromResult(machine);
        }
    }
}

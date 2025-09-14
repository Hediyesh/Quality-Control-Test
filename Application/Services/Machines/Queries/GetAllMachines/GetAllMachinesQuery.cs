using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Queries.GetAllMachines
{
    public class GetAllMachinesQuery : IRequest<List<MachineDto>>
    {
    }
}

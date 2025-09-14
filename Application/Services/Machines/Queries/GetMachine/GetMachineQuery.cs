using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Queries.GetMachine
{
    public class GetMachineQuery : IRequest<MachineDto>
    {
        public int Id { get; set; }
    }
}

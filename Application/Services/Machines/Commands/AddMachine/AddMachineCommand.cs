using ControlService.ControlApplication.Services;
using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Commands.AddMachine
{
    public class AddMachineCommand : IRequest<MachineDto>
    {
        public string MachineName { get; set; }
        public int CompanyId { get; set; }
    }
}

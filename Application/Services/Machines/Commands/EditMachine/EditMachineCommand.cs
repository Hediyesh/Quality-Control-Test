using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Commands.EditMachine
{
    public class EditMachineCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public int CompanyId { get; set; }
    }
}

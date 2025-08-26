using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services
{
    public class MachineDto
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public int CompanyId { get; set; }

    }
}

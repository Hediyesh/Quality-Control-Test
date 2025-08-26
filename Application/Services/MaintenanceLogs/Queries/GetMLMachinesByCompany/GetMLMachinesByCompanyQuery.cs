using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetMLMachinesByCompany
{
    public class GetMLMachinesByCompanyQuery : IRequest<List<Machine>>
    {
        public int companyId { get; set; }
    }
}

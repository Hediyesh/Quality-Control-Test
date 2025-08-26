using ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetMaintenanceLog
{
    public class GetMaintenanceLogQuery: IRequest<GetMaintenanceLogsDto>
    {
        public int mlId { get; set; }   
    }
}

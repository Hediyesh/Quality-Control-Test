using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs
{
    public class GetAllMaintenanceLogsQuery: IRequest<List<GetMaintenanceLogsDto>>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.DeleteMaintenanceLogs
{
    public class DeleteMaintenanceLogCommand: IRequest<ResultDto>
    {
        public int mlId { get; set; }
    }
}

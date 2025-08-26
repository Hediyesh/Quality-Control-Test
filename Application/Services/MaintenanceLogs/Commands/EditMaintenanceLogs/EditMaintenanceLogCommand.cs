using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.EditMaintenanceLogs
{
    public class EditMaintenanceLogCommand: IRequest<ResultDto>
    {
        public int mlId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public float HoursSpent { get; set; }
        public DateTime? NextScheduleDate { get; set; }
        public int MachineId { get; set; }
        public int? PersonId { get; set; }
        public int MaintenanceId { get; set; }
        public int MaintenanceLogStatusId { get; set; }
        public int CompanyId { get; set; }
    }
}

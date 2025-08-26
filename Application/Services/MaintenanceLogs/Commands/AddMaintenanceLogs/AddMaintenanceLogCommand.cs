using MediatR;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.AddMaintenanceLogs
{
    public class AddMaintenanceLogCommand: IRequest<ResultDto>
    {
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public float HoursSpent { get; set; }
        public DateTime? NextScheduleDate { get; set; }
        public int MachineId { get; set; }
        public int? PersonId { get; set; }
        // this is mlTypeId
        public int MaintenanceId { get; set; }
        public int MaintenanceLogStatusId { get; set; }
        public int CompanyId { get; set; }
    }
}

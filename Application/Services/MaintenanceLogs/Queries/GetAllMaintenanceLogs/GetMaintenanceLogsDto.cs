namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs
{
    public class GetMaintenanceLogsDto
    {
        public int MLId { get; set; }
        //public DateTime MaintenanceDate { get; set; }
        public string MaintenanceDate { get; set; }
        public string Description { get; set; }
        public float HoursSpent { get; set; }
        //public DateTime? NextScheduleDate { get; set; }
        public string? NextScheduleDate { get; set; }
        public string MachineName { get; set; }
        public string? PersonName { get; set; }
        public string MaintenanceTypeName { get; set; }
        public string MaintenanceLogStatusName { get; set; }
        public string CompanyName { get; set; }

    }
}

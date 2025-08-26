using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class MaintenanceLogStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}

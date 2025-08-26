using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class MaintenanceType
    {
        [Key]
        public int MaintenanceId { get; set; }
        public string MaintenanceTypeName { get; set; }
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}

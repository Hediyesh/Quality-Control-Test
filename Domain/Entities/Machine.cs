using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public ICollection<QualityControlEntry>? QualityControlEntries { get; set; }

        // Foreign key
        public int CompanyId { get; set; }

        // Navigation property
        public Company Company { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}

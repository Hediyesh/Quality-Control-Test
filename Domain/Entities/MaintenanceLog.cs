using ControlDomain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlService.ControlDomain.Entities
{
    public class MaintenanceLog
    {
        [Key]
        public int MLId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public float HoursSpent { get; set; }
        public DateTime? NextScheduleDate { get; set; }
        [ForeignKey("Machine")]
        // Foreign key
        public int MachineId { get; set; }

        // Navigation property
        public Machine Machine { get; set; }
        [ForeignKey("Person")]
        // Foreign key
        public int? PersonId { get; set; }

        // Navigation property
        //public Person? Person { get; set; }
        [ForeignKey("MaintenanceType")]
        // Foreign key
        public int MaintenanceId { get; set; }

        // Navigation property
        public MaintenanceType MaintenanceType { get; set; }
        [ForeignKey("MaintenanceLogStatus")]
        // Foreign key
        public int MaintenanceLogStatusId { get; set; }

        // Navigation property
        public MaintenanceLogStatus MaintenanceLogStatus { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<MLTools>? MLTools { get; set; }
    }
}

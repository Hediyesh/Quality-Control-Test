using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlService.ControlDomain.Entities
{
    public class QualityControlEntry
    {
        [Key]
        public int QCEId { get; set; }
        public DateTime InspectionDate { get; set; }
        public int QuantityInspected { get; set; }
        public int QualityDefective { get; set; }
        public string DefectDescription { get; set; }
        public string? RootCause { get; set; }
        public string? CorrectiveAction { get; set; }
        [ForeignKey("Batch")]
        // Foreign key
        public int BatchId { get; set; }

        // Navigation property
        public Batch Batch { get; set; }
        [ForeignKey("Severity")]
        // Foreign key
        public int SeverityId { get; set; }

        // Navigation property
        public Severity Severity { get; set; }
        [ForeignKey("Defect")]
        // Foreign key
        public int DefectId { get; set; }

        // Navigation property
        public Defect Defect { get; set; }
        [ForeignKey("Machine")]
        // Foreign key
        public int? MachineId { get; set; }

        // Navigation property
        public Machine? Machine { get; set; }
        [ForeignKey("Product")]
        // Foreign key
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }
        [ForeignKey("Person")]
        // Foreign key
        public int? PersonId { get; set; }

        // Navigation property
        //public Person? Person { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

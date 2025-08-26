using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Severity
    {
        [Key]
        public int SeverityId { get; set; }
        public string SeverityDescription { get; set; }
        public ICollection<QualityControlEntry> QualityControlEntries { get; set; }
    }
}

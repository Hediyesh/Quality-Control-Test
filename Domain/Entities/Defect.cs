using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Defect
    {
        [Key]
        public int DefectId { get; set; }
        public string DefectType { get; set; }
        public ICollection<QualityControlEntry> QualityControlEntries { get; set; }
    }
}

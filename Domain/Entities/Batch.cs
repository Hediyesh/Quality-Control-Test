using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchNumber { get; set; }
        public ICollection<QualityControlEntry> QualityControlEntries { get; set; }
    }
}

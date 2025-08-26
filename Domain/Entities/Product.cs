using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductSKU { get; set; }
        public string ProductName { get; set; }
        // Foreign key
        public int CompanyId { get; set; }

        // Navigation property
        public Company Company { get; set; }
        public ICollection<Machine>? Machines { get; set; }
        public ICollection<QualityControlEntry> QualityControlEntries { get; set; }
        // Foreign key
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ControlService.ControlDomain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

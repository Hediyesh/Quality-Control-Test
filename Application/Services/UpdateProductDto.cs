namespace ControlService.ControlApplication.Services
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public List<int>? Machines { get; set; }
    }
}

namespace Client.Models
{
    public class GetQCEProductsMachinesByCompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<MachineViewModel>? Machines { get; set; }
        public List<ProductViewModel>? Products { get; set; }
    }
}

namespace Client.Models
{
    public class GetDropDownForEditOrAddQCEViewModel
    {
        public int qceId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int? QuantityInspected { get; set; }
        public int? QualityDefective { get; set; }
        public string DefectDescription { get; set; }
        public string? RootCause { get; set; }
        public string? CorrectiveAction { get; set; }
        public List<BatchViewModel> Batches { get; set; }
        public int? BatchId { get; set; }
        public string? BatchNumber { get; set; }
        public List<SeverityViewModel> Severities { get; set; }
        public int? SeverityId { get; set; }
        public string? SeverityName { get; set; }
        public List<DefectViewModel> Defects { get; set; }
        public int? DefectId { get; set; }
        public string? DefectName { get; set; }
        public List<MachineViewModel> Machines { get; set; }
        public int? MachineId { get; set; }
        public string? MachineName { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<PersonViewModel> Persons { get; set; }
        public int? PersonId { get; set; }
        public string? PersonName { get; set; }
        public List<CompanyViewModel> Companies { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
    }
}

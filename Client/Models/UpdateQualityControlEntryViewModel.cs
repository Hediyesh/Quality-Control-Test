namespace Client.Models
{
    public class UpdateQualityControlEntryViewModel
    {
        public DateTime InspectionDate { get; set; }
        public int QuantityInspected { get; set; }
        public int QualityDefective { get; set; }
        public string DefectDescription { get; set; }
        public string? RootCause { get; set; }
        public string? CorrectiveAction { get; set; }
        public int BatchId { get; set; }
        public int SeverityId { get; set; }
        public int DefectId { get; set; }
        public int? MachineId { get; set; }
        public int ProductId { get; set; }
        public int? PersonId { get; set; }
        public int CompanyId { get; set; }
    }
}

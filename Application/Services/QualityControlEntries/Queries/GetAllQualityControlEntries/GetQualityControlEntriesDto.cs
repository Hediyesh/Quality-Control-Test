using MediatR;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetAllQualityControlEntries
{
    public class GetQualityControlEntriesDto :IRequest
    {
        public int QCEId { get; set; }
        //public DateTime InspectionDate { get; set; }
        public string InspectionDate { get; set; }
        public int QuantityInspected { get; set; }
        public int QualityDefective { get; set; }
        public string DefectDescription { get; set; }
        public string? RootCause { get; set; }
        public string? CorrectiveAction { get; set; }
        public string BatchNumber { get; set; }
        public string Severity { get; set; }
        public string Defect { get; set; }
        public string? MachineName { get; set; }
        public string ProductName { get; set; }
        public string? PersonName { get; set; }
        public string CompanyName { get; set; }
    }
}

using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetDropDownForEditOrAddQCE
{
    public class GetDropDownForEditOrAddQCEDto
    {
        public int qceId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int? QuantityInspected { get; set; }
        public int? QualityDefective { get; set; }
        public string DefectDescription { get; set; }
        public string? RootCause { get; set; }
        public string? CorrectiveAction { get; set; }
        public List<BatchDto> Batches { get; set; }
        public int? BatchId { get; set; }
        public string? BatchNumber { get; set; }
        public List<SeverityDto> Severities { get; set; }
        public int? SeverityId { get; set; }
        public string? SeverityName { get; set; }
        public List<DefectDto> Defects { get; set; }
        public int? DefectId { get; set; }
        public string? DefectName { get; set; }
        public List<MachineDto> Machines { get; set; }
        public int? MachineId { get; set; }
        public string? MachineName { get; set; }
        public List<ProductDto> Products { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<PersonDto> Persons { get; set; }
        public int? PersonId { get; set; }
        public string? PersonName { get; set; }
        public List<CompanyDto> Companies { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

    }
}

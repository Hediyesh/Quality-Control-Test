using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetDataForEditOrAddML
{
    public class GetDataForEditOrAddMLDto
    {
        public int? MLId { get; set; }
        public DateTime? MLDate { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public string? MaintenanceTypeName { get; set; }
        public int? PersonId { get; set; }
        public string? PersonName { get; set; }
        public int? MachineId { get; set; }
        public string? MachineName { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? Description { get; set; }
        public float? HoursSpent { get; set; }
        public DateTime? NextScheduleDate { get; set; }
        public List<Machine> machines { get; set; }
        public List<Company> companies { get; set; }
        public List<MaintenanceLogStatus> statuses { get; set; }
        // * public List<Person> persons { get;set; }
        public List<MaintenanceType> maintenanceTypes { get; set; }
    }
}

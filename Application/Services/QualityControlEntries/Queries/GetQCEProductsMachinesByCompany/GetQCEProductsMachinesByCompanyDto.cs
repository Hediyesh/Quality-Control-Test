using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQCEProductsMachinesByCompany
{
    public class GetQCEProductsMachinesByCompanyDto
    {
        public int CompanyId { get; set; } 
        public string CompanyName { get; set; } 
        public List<MachineDto>? Machines { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}

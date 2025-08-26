using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.CompanyCategoriesMachines.GetCompanyCategoriesMachines
{
    public class GetCompanyCategoriesMachinesDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Category>? categories { get; set; }
        public List<Machine>? machines { get; set; }
    }
}

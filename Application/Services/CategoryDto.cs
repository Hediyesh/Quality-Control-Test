using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
    }
}

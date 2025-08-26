using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductSKU { get; set; }
        public string ProductName { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }


    }
}

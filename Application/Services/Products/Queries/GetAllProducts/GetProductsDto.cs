using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ControlService.ControlDomain.Entities;

namespace ControlService.ControlApplication.Services.Products.Queries.GetAllProducts
{
    public class GetProductsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<GetProductMachineDto>? Machines { get; set; }

    }
}

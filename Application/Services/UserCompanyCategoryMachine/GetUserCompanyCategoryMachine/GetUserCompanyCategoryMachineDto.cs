using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using ControlService.ControlDomain.Entities;

namespace ControlService.ControlApplication.Services.UserCompanyCategoryMachine.GetUserCompanyCategoryMachine
{
    public class GetUserCompanyCategoryMachineDto
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public List<CompanyDto>? companies { get; set; }
        public List<CategoryDto> categories { get; set; }
        public List<GetProductMachineDto> machines { get; set; }
        public List<GetProductMachineDto>? selectedMachines { get; set; }
        public GetProductsDto? Product { get; set; }
    }
}

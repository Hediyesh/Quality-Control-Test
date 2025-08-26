using ControlService.ControlApplication.Services;
using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using ControlService.ControlApplication.Services.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControlService.Areas.Admin.Models
{
    public class EditOrCreateProductViewModel
    {
        public ProductDto Product { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Machines { get; set; }
        public List<SelectListItem> Companies { get; set; }

        //public List<int> SelectedMachineIds { get; set; }
        //public AppUser AppUser { get; set; }
    }
}

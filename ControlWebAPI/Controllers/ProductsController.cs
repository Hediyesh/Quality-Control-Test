using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.CompanyCategoriesMachines.GetCompanyCategoriesMachines;
using ControlService.ControlApplication.Services.Products.Commands.AddProduct;
using ControlService.ControlApplication.Services.Products.Commands.DeleteProduct;
using ControlService.ControlApplication.Services.Products.Commands.EditProduct;
using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using ControlService.ControlApplication.Services.Products.Queries.GetProduct;
using ControlService.ControlApplication.Services.UserCompanyCategoryMachine.GetUserCompanyCategoryMachine;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlEndPoint.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductQuery { ProductId = id });
            List<GetProductsDto> productsDtos = new List<GetProductsDto>();
            productsDtos.Add(product);
            return Ok(productsDtos);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("داده خالی است!");
            }
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [AcceptVerbs("PUT")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] UpdateProductDto dto)
        {
            if (dto == null)
            {
                return BadRequest("داده خالی است!");
            }
            var result = await _mediator.Send(new EditProductCommand
            {
                ProductId = id,
                ProductName = dto.ProductName,
                CategoryId = dto.CategoryId,
                CompanyId = dto.CompanyId,
                Machines = dto.Machines
            });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [AcceptVerbs("DELETE")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { ProductId = id });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpGet("UpdateMachinesCategoriesByCompany")]
        public async Task<IActionResult> UpdateMachinesCategoriesByCompany(int id)
        {
            var data = await _mediator.Send(new GetCompanyCategoriesMachinesQuery { companyId = id });
            return Ok(new
            {
                categories = data.categories?.Select(c => new { categoryId = c.CategoryId, categoryName = c.CategoryName }),
                machines = data.machines?.Select(m => new { machineId = m.MachineId, machineName = m.MachineName })
            });
        }
        [HttpGet("EditOrCreatePartial")]
        public async Task<ActionResult> EditOrCreatePartial(int? id)
        {
            var userid = User.Identity?.Name; //gets username
            var list = await _mediator.Send(new GetUserCompanyCategoryMachineQuery { UserName = userid, ProductId = id });
            return Ok(list);
        }
    }
}

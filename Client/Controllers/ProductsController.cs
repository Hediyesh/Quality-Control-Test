//using Control.Application.Interfaces.Contexts;
//using Control.Application.Services.CompanyCategoriesMachines.GetCompanyCategoriesMachines;
//using Control.Application.Services.Products.Commands.AddProduct;
//using Control.Application.Services.Products.Commands.DeleteProduct;
//using Control.Application.Services.Products.Commands.EditProduct;
//using Control.Application.Services.Products.Queries.GetAllProducts;
//using Control.Application.Services.Products.Queries.GetProduct;
//using Control.Application.Services.UserCompanyCategoryMachine.GetUserCompanyCategoryMachine;
//using Endpoint.Control.Dtos;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace ControlEndPoint.Controllers
//{
//    [Authorize(Roles = "admin")]
//    [Area("Admin")]
//    //[ApiController]
//    //[Route("api/[controller]")]
//    public class ProductsController : Controller
//    {
//        private readonly IMediator _mediator;
//        public ProductsController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllProducts()
//        {
//            var products = await _mediator.Send(new GetAllProductQuery());
//            return View(products);
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProduct(int id)
//        {
//            var product = await _mediator.Send(new GetProductQuery { ProductId = id });
//            List<GetProductsDto> productsDtos = new List<GetProductsDto>();
//            productsDtos.Add(product);
//            return View("GetAllProducts", productsDtos);
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
//        {
//            if (command == null)
//            {
//                return BadRequest("داده خالی است!");
//            }
//            var result = await _mediator.Send(command);

//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        //[HttpPut("{id}")]
//        [AcceptVerbs("PUT")]
//        public async Task<IActionResult> EditProduct(int id, [FromBody] UpdateProductDto dto)
//        {
//            if (dto == null)
//            {
//                return BadRequest("داده خالی است!");
//            }
//            var result = await _mediator.Send(new EditProductCommand
//            {
//                ProductId = id,
//                ProductName = dto.ProductName,
//                CategoryId = dto.CategoryId,
//                CompanyId = dto.CompanyId,
//                Machines = dto.Machines
//            });

//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        //[HttpDelete("{id}")]
//        [AcceptVerbs("DELETE")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            var result = await _mediator.Send(new DeleteProductCommand { ProductId = id });

//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        [HttpGet]
//        public async Task<IActionResult> UpdateMachinesCategoriesByCompany(int id)
//        {
//            var data = await _mediator.Send(new GetCompanyCategoriesMachinesQuery { companyId = id });
//            return Json(new
//            {
//                categories = data.categories?.Select(c => new { categoryId = c.CategoryId, categoryName = c.CategoryName }),
//                machines = data.machines?.Select(m => new { machineId = m.MachineId, machineName = m.MachineName })
//            });
//        }
//        [HttpGet]
//        public async Task<ActionResult> EditOrCreatePartial(int? id)
//        {
//            var userid = User.Identity?.Name; //gets username
//            var list = await _mediator.Send(new GetUserCompanyCategoryMachineQuery { UserName = userid, ProductId = id });
//            return PartialView(list);
//        }
//    }
//}

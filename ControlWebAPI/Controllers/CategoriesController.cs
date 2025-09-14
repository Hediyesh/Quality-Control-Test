using ControlApplication.Services;
using ControlApplication.Services.Categories.Commands.AddCategory;
using ControlApplication.Services.Categories.Commands.DeleteCategory;
using ControlApplication.Services.Categories.Commands.EditCategory;
using ControlApplication.Services.Categories.Queries.GetAllCategories;
using ControlApplication.Services.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var Categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(Categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var Category = await _mediator.Send(new GetCategoryQuery { Id = id });
            return Ok(Category);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            //if (command == null)
            //{
            //    return BadRequest("داده خالی است!");
            //}
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> EditCategory(int id, [FromBody] UpdateCategoryDto dto)
        {
            //if (dto == null)
            //{
            //    return BadRequest("داده خالی است!");
            //}
            var result = await _mediator.Send(new EditCategoryCommand
            {
                Id = id,
                CategoryName = dto.CategoryName,
                CompanyId = dto.CompanyId,
            });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}

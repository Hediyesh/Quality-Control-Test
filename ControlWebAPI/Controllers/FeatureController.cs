using ControlApplication.Services;
using ControlApplication.Services.Categories.Commands.AddCategory;
using ControlApplication.Services.Categories.Commands.DeleteCategory;
using ControlApplication.Services.Categories.Commands.EditCategory;
using ControlApplication.Services.Categories.Queries.GetAllCategories;
using ControlApplication.Services.Categories.Queries.GetCategory;
using ControlApplication.Services.Features.Commands.DeleteFeature;
using ControlApplication.Services.Features.Queries.GetAllFeatures;
using ControlApplication.Services.Features.Queries.GetAllFeaturesTree;
using ControlApplication.Services.Features.Queries.GetFeature;
using ControlDomain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : Controller
    {
        private readonly IMediator _mediator;
        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _mediator.Send(new GetAllFeaturesQuery());
            return Ok(features);
        }
        [HttpGet("GetAllFeaturesTree/")]
        public async Task<IActionResult> GetAllFeaturesTree()
        {
            var features = await _mediator.Send(new GetAllFeaturesTreeQuery());
            return Ok(features);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(Guid id)
        {
            var feature = await _mediator.Send(new GetFeatureQuery { Id = id });
            return Ok(feature);
        }
        //[HttpPost]
        //public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        //{
            
        //    var result = await _mediator.Send(command);

        //    if (!result.IsSuccess)
        //        return BadRequest(result.Message);

        //    return Ok(result.Message);
        //}
        //[HttpPut]
        //public async Task<IActionResult> EditCategory(int id, [FromBody] UpdateCategoryDto dto)
        //{
            
        //    var result = await _mediator.Send(new EditCategoryCommand
        //    {
        //        Id = id,
        //        CategoryName = dto.CategoryName,
        //        CompanyId = dto.CompanyId,
        //    });

        //    if (!result.IsSuccess)
        //        return BadRequest(result.Message);

        //    return Ok(result.Message);
        //}
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature([FromQuery] Guid Id, [FromQuery] int NodeId, [FromQuery] Types Type)
        {
            var result = await _mediator.Send(new DeleteFeatureQuery { Id = Id, NodeId = NodeId, Type = Type });
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}

using ControlApplication.Services.Categories.Queries.GetAllCategories;
using ControlApplication.Services.TreeNodes.GetAllTreeNodes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreeNodesController : Controller
    {
        private readonly IMediator _mediator;
        public TreeNodesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTreeNodes()
        {
            var treeNodes = await _mediator.Send(new GetAllTreeNodesQuery());
            return Ok(treeNodes);
        }
    }
}

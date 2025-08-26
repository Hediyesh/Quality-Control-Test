using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolsWebApi.Models;

namespace ToolsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : Controller
    {
        private readonly ToolsDbContext _context;

        public ToolsController(ToolsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tool>>> GetAllTools()
        {
            var tools = await _context.Tools.ToListAsync();
            return Ok(tools);
        }
    }
}

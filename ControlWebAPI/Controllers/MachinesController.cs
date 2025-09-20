using ControlApplication.Services;
using ControlApplication.Services.Machines.Commands.AddMachine;
using ControlApplication.Services.Machines.Commands.DeleteMachine;
using ControlApplication.Services.Machines.Commands.EditMachine;
using ControlApplication.Services.Machines.Queries.GetAllMachines;
using ControlApplication.Services.Machines.Queries.GetMachine;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : Controller
    {
        private readonly IMediator _mediator;
        public MachinesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMachines()
        {
            var Machines = await _mediator.Send(new GetAllMachinesQuery());
            return Ok(Machines);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine(int id)
        {
            var Machine = await _mediator.Send(new GetMachineQuery { Id = id });
            return Ok(Machine);
        }
        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody] AddMachineCommand command)
        {
            //if (command == null)
            //{
            //    return BadRequest("داده خالی است!");
            //}
            var result = await _mediator.Send(command);

            //if (!result.IsSuccess)
            //    return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> EditMachine(int id, [FromBody] UpdateMachineDto dto)
        {
            //if (dto == null)
            //{
            //    return BadRequest("داده خالی است!");
            //}
            var result = await _mediator.Send(new EditMachineCommand
            {
                Id = id,
                MachineName = dto.MachineName,
                CompanyId = dto.CompanyId,
            });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var result = await _mediator.Send(new DeleteMachineCommand { Id = id });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}

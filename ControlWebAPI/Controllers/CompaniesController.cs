using MediatR;
using Microsoft.AspNetCore.Mvc;
using ControlApplication.Services.Companies.Queries.GetAllCompanies;
using ControlApplication.Services.Companies.Queries.GetCompany;
using ControlApplication.Services.Companies.Commands.AddCompany;
using ControlApplication.Services.Companies.Commands.EditCompany;
using ControlApplication.Services;
using ControlApplication.Services.Companies.Commands.DeleteCompany;

namespace ControlWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var Companies = await _mediator.Send(new GetAllCompaniesQuery());
            return Ok(Companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var Company = await _mediator.Send(new GetCompanyQuery { Id = id });
            return Ok(Company);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyCommand command)
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
        public async Task<IActionResult> EditCompany(int id, [FromBody] UpdateCompanyDto dto)
        {
            //if (dto == null)
            //{
            //    return BadRequest("داده خالی است!");
            //}
            var result = await _mediator.Send(new EditCompanyCommand
            {
                Id = id,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Address = dto.Address,
                CompanyName = dto.CompanyName
            });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand { Id = id });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}

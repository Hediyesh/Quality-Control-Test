using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApplication.Services.LoginService.Commands.Login;

namespace UserEndPoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return Ok("login OK");
        //}
    }
}

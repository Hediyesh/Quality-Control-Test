using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendEmailApplication.Interfaces.Contexts;

namespace SendEmailEndPoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILoginEmailService _loginEmailService;

        public EmailController(ILoginEmailService loginEmailService)
        {
            _loginEmailService = loginEmailService;
        }

        [HttpPost("send-login-email")]
        public async Task<IActionResult> SendLoginEmail([FromBody] LoginEmailRequest request)
        {
            if (request == null
                || string.IsNullOrEmpty(request.UserId)
                || string.IsNullOrEmpty(request.UserEmail)
                || string.IsNullOrEmpty(request.UserName))
            {
                return BadRequest("Invalid data");
            }

            await _loginEmailService.SendLoginEmailAsync(
                request.UserId,
                request.UserName,
                request.UserEmail,
                request.LoginTime
            );

            return Ok(new { Success = true, Message = "Login email sent." });
        }
    }

    public class LoginEmailRequest
    {
        public string UserId { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string UserEmail { get; set; } = default!;
        public DateTime LoginTime { get; set; }
    }

}

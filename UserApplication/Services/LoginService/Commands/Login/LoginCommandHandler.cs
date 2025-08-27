using Contracts.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Interfaces;
using UserDomain.Entities;

namespace UserApplication.Services.LoginService.Commands.Login
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPublishEndpoint _publishEndpoint;

        public LoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwtTokenGenerator,
            IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _publishEndpoint = publishEndpoint;
        }


        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByEmailAsync(request.Email.Trim().ToLower());
            //if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            //    return new LoginDto { Success = false, Message = "اطلاعات وارد شده اشتباه است." };
            var user = await _userManager.FindByEmailAsync(request.Email.Trim().ToLower());
            if (user == null)
                return new LoginDto { Success = false, Message = "کاربری با این ایمیل یافت نشد." };

            var passCheck = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passCheck)
                return new LoginDto { Success = false, Message = "رمز عبور اشتباه است." };

            var token = _jwtTokenGenerator.GenerateToken(user);
            // todo: make RabbitMQ work
            // ارسال ایونت به RabbitMQ
            //await _publishEndpoint.Publish(new UserLoggedInEvent
            //{
            //    Email = request.Email,
            //    UserId = user.Id,
            //    UserName = user.UserName,
            //    LoginTime = DateTime.UtcNow
            //});
            return new LoginDto { Token = token, Success = true, Message = "ورود موفق" };
        }
    }
}

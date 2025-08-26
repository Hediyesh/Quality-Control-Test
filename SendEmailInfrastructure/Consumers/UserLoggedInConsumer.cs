using Contracts.Events;
using MassTransit;
using SendEmailApplication.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailInfrastructure.Consumers
{
    public class UserLoggedInConsumer : IConsumer<UserLoggedInEvent>
    {
        private readonly ILoginEmailService _loginEmailService;

        public UserLoggedInConsumer(ILoginEmailService loginEmailService)
        {
            _loginEmailService = loginEmailService;
        }

        public async Task Consume(ConsumeContext<UserLoggedInEvent> context)
        {
            var message = context.Message;
            await _loginEmailService.SendLoginEmailAsync(
                message.UserId,
                message.UserName,
                message.Email,
                message.LoginTime
            );
        }
    }
}

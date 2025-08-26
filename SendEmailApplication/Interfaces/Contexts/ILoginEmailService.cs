using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailApplication.Interfaces.Contexts
{
    public interface ILoginEmailService
    {
        Task SendLoginEmailAsync(string userId, string userName, string userEmail, DateTime loginTime);
    }
}

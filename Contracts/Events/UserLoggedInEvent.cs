using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class UserLoggedInEvent
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } = default!;
        public DateTime LoginTime { get; set; }
    }
}

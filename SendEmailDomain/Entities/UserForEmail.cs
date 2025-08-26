using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailDomain.Entities
{
    public class UserForEmail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }
        [MaxLength(250)]
        public string UserName { get; set; }
        [MaxLength(250)]
        public string UserEmail { get; set; }
    }
}

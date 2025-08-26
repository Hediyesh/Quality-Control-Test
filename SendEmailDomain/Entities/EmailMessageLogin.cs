using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailDomain.Entities
{
    public class EmailMessageLogin
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public UserForEmail user { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(450)]
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public DateTime Created { get; set; }

    }
}

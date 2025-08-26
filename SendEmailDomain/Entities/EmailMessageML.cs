using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailDomain.Entities
{
    public class EmailMessageML
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("useSent")]
        public int UserSentId { get; set; }
        public UserForEmail userSent { get; set; }
        [ForeignKey("emailForMaintenanceLog")]
        public int emailMLId { get; set; }
        public EmailForMaintenanceLog emailForMaintenanceLog { get; set; }
        //[MaxLength(250)]
        //public string To { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(450)]
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public DateTime Created { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailDomain.Entities
{
    public class EmailForMaintenanceLog
    {
        [Key]
        public int Id { get; set; }
        public int MLId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string MachineName { get; set; }
        [MaxLength(250)]
        public string CompanyName { get; set; }

    }
}

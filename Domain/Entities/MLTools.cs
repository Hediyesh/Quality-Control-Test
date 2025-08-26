using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDomain.Entities
{
    public class MLTools
    {
        [Key]
        public int Id { get; set; }
        public ICollection<MaintenanceLog>? MaintenanceLogs { get; set; }
        public int Count { get; set; }
        public int ToolId { get; set; }
        [MaxLength(250)]
        public string ToolName { get; set; }
    }
}

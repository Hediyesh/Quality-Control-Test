using ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services
{
    public class TreeNodeDto
    {
        public Guid Id { get; set; }
        public int NodeId { get; set; }
        public Types Type { get; set; }
        public string Label { get; set; }
        public List<TreeNodeDto> Children { get; set; } = new List<TreeNodeDto>();
    }
}

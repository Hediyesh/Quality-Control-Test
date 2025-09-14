using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.TreeNodes
{
    public class TreeNodeDto
    {
        public int Id { get; set; }
        public Types Type { get; set; }
        public string Name { get; set; }
        public List<TreeNodeDto> Children { get; set; } = new List<TreeNodeDto>();
    }
}

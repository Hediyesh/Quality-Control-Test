using ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services
{
    public class FeatureDto
    {
        public Guid Id { get; set; }
        public int? NodeId { get; set; }
        public Types Type { get; set; }
        public string Label { get; set; }
        public byte[] Node { get; set; }
        public string? NodePath { get; set; }
        public List<FeatureDto> Children { get; set; } = new();
    }
}

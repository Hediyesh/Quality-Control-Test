using ControlService.ControlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDomain.Entities
{
    public class Feature
    {
        public Guid Id { get; set; }
        public int? NodeId { get; set; }
        public Types Type { get; set; }
        public string Label { get; set; }
        //public Guid? ParentId { get; set; }

        public byte[] Node { get; set; } // hierarchyid

        // Navigation
        public Company? Company { get; set; }
        public Machine? Machine { get; set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }
    }
}

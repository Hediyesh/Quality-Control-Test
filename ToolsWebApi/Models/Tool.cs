using System.ComponentModel.DataAnnotations;

namespace ToolsWebApi.Models
{
    public class Tool
    {
        [Key]
        public int ToolId { get; set; }
        [MaxLength(250)]
        public string ToolName { get; set; }
        public int Count { get; set; }
    }
}

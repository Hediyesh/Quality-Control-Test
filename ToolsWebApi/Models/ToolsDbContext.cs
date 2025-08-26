using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ToolsWebApi.Models
{
    public class ToolsDbContext : DbContext
    {
        public ToolsDbContext(DbContextOptions<ToolsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
    }

}

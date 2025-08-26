using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class MaintenanceLogConfig: IEntityTypeConfiguration<MaintenanceLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MaintenanceLog> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(255);
        }
    }
}

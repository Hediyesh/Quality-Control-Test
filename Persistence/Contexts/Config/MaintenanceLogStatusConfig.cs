using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class MaintenanceLogStatusConfig: IEntityTypeConfiguration<MaintenanceLogStatus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MaintenanceLogStatus> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(100);
        }
    }
}

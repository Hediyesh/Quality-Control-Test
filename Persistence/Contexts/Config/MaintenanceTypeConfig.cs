using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class MaintenanceTypeConfig: IEntityTypeConfiguration<MaintenanceType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MaintenanceType> builder)
        {
            builder.Property(x => x.MaintenanceTypeName).HasMaxLength(100);
        }
    }
}

using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class QualityControlEntryConfig : IEntityTypeConfiguration<QualityControlEntry>
    {
            public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<QualityControlEntry> builder)
            {
                builder.Property(x => x.DefectDescription).HasMaxLength(255);
                builder.Property(x => x.RootCause).HasMaxLength(255);
                builder.Property(x => x.CorrectiveAction).HasMaxLength(255);
            }
    }
}

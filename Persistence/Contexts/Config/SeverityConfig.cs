using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class SeverityConfig: IEntityTypeConfiguration<Severity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Severity> builder)
        {
            builder.Property(x => x.SeverityDescription).HasMaxLength(100);
        }
    }
}

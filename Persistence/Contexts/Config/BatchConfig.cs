using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class BatchConfig: IEntityTypeConfiguration<Batch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Batch> builder)
        {
            builder.Property(x => x.BatchNumber).HasMaxLength(255);
        }
    }
}

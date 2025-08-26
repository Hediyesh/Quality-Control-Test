using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class MachineConfig: IEntityTypeConfiguration<Machine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Machine> builder)
        {
            builder.Property(x => x.MachineName).HasMaxLength(255);
        }
    }
}

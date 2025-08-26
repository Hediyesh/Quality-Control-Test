using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersistence.Contexts.Config
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasMaxLength(255);
        }
    }
}

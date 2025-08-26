using Microsoft.EntityFrameworkCore;
using SendEmailDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailApplication.Interfaces.Contexts
{
    public interface IEmailDbContext
    {
        DbSet<EmailForMaintenanceLog> EmailForMaintenanceLogs { get; set; }
        DbSet<EmailMessageML> EmailMessageMLs { get; set; }
        DbSet<UserForEmail> UserForEmails { get; set; }
        DbSet<EmailMessageLogin> EmailMessageLogins { get; set; }
        //int SaveChanges(bool acceptAllChangesOnSuccess);
        //int SaveChanges();
        //Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}

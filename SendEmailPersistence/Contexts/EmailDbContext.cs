using Microsoft.EntityFrameworkCore;
using SendEmailApplication.Interfaces.Contexts;
using SendEmailDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailPersistence.Contexts
{
    public class EmailDbContext : DbContext, IEmailDbContext
    {
        public EmailDbContext(DbContextOptions<EmailDbContext> options)
        : base(options)
        {
        }
        public DbSet<EmailForMaintenanceLog> EmailForMaintenanceLogs { get; set; }
        public DbSet<EmailMessageML> EmailMessageMLs { get; set; }
        public DbSet<UserForEmail> UserForEmails { get; set; }
        public DbSet<EmailMessageLogin> EmailMessageLogins { get; set; }
        //public int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    throw new NotImplementedException();
        //}

        //public int SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailMessageML>()
                .HasOne(q => q.emailForMaintenanceLog)
                .WithMany()
                .HasForeignKey(q => q.emailMLId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmailMessageML>()
                .HasOne(q => q.userSent)
                .WithMany()
                .HasForeignKey(q => q.UserSentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmailMessageLogin>()
                .HasOne(q => q.user)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

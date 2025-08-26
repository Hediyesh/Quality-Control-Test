using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApplication.Interfaces;
using UserDomain.Entities;

namespace UserPersistence.Contexts
{
    public class UserDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, IUserDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // محدود کردن همه string‌ها به 450
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    if (prop.GetMaxLength() == null)
                        prop.SetMaxLength(450);
                }
            }

            builder.Entity<Person>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

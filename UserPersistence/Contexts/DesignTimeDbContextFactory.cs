using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserPersistence.Contexts;

public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    public UserDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();

        // رشته اتصال مناسب برای لوکال دیتابیس یا چیزی که در appsettings.json هست
        optionsBuilder.UseSqlServer("Server=.;Database=msUserDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new UserDbContext(optionsBuilder.Options);
    }
}

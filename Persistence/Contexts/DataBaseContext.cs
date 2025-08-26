using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using ControlPersistence.Contexts.Config;
using Microsoft.EntityFrameworkCore;
using ControlDomain.Entities;

namespace ControlService.ControlPersistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
        {
        }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<QualityControlEntry> QualityControlEntries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<MaintenanceLogStatus> MaintenanceLogStatuses { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Defect> Defects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<MLTools> MLTools { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BatchConfig).Assembly);

            // Many-to-many Machine <-> Product
            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Products)
                .WithMany(p => p.Machines)
                .UsingEntity<Dictionary<string, object>>(
                    "MachineProduct",
                    j => j
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict),  // Restrict here
                    j => j
                        .HasOne<Machine>()
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)    // Cascade here
                );


            modelBuilder.Entity<MLTools>()
                .HasMany(m => m.MaintenanceLogs)
                .WithMany(p => p.MLTools)
                .UsingEntity<Dictionary<string, object>>(
                    "MaintenanceLogTools",
                    j => j
                        .HasOne<MaintenanceLog>()
                        .WithMany()
                        .HasForeignKey("MLId")
                        .OnDelete(DeleteBehavior.Restrict),  // Restrict here
                    j => j
                        .HasOne<MLTools>()
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)    // Cascade here
                );


            // QualityControlEntry foreign keys (all Restrict)
            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Batch)
                .WithMany()
                .HasForeignKey(q => q.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Defect)
                .WithMany()
                .HasForeignKey(q => q.DefectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Machine)
                .WithMany()
                .HasForeignKey(q => q.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Product)
                .WithMany()
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Severity)
                .WithMany()
                .HasForeignKey(q => q.SeverityId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<QualityControlEntry>()
            //    .HasOne(q => q.Person)
            //    .WithMany()
            //    .HasForeignKey(q => q.PersonId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // MaintenanceLog foreign keys
            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(ml => ml.Machine)
                .WithMany()
                .HasForeignKey(ml => ml.MachineId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade here (example)

            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(ml => ml.MaintenanceLogStatus)
                .WithMany()
                .HasForeignKey(ml => ml.MaintenanceLogStatusId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict here

            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(ml => ml.MaintenanceType)
                .WithMany()
                .HasForeignKey(ml => ml.MaintenanceId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict here

            //modelBuilder.Entity<MaintenanceLog>()
            //    .HasOne(ml => ml.Person)
            //    .WithMany()
            //    .HasForeignKey(ml => ml.PersonId)
            //    .OnDelete(DeleteBehavior.Restrict); // Restrict here

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Company)
                .WithMany(co => co.Categories)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<QualityControlEntry>()
                .HasOne(q => q.Company)
                .WithMany(co => co.QualityControlEntries)
                .HasForeignKey(q => q.CompanyId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(m => m.Company)
                .WithMany(co => co.MaintenanceLogs)
                .HasForeignKey(m => m.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using ControlDomain.Entities;
using ControlService.ControlDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlService.ControlApplication.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<Severity> Severities { get; set; }
        DbSet<QualityControlEntry> QualityControlEntries { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        DbSet<MaintenanceLogStatus> MaintenanceLogStatuses { get; set; }
        DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        DbSet<Machine> Machines { get; set; }
        DbSet<Defect> Defects { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Batch> Batchs { get; set; }
        DbSet<MLTools> MLTools { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}

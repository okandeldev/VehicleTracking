
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace VehicleAPI.Infrastructure.Persistence
{
    public class VehicleContext : DbContext
    {

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Vehicle>().HasData(VehicleSeed.Vehicles);
            modelBuilder.Entity<VehicleStatus>().HasData(VehicleSeed.VehicleStatuses);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleStatus> VehicleStatues { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditOnCreateEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "System User";
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<IAuditOnUpdateEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = "System User";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

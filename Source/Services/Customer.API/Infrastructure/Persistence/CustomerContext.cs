
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace CustomerAPI.Infrastructure.Persistence
{
    public class CustomerContext : DbContext
    { 
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Customer>().HasData(CustomerSeed.Customers); 
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; } 

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

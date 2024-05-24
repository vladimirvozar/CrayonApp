using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<SoftwareProduct> SoftwareProducts { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<PerpetualLicense> PerpetualLicenses { get; set; }
        public DbSet<ConcurrentLicense> ConcurrentLicenses { get; set; }
        public DbSet<SubscriptionBasedLicense> SubscriptionBasedLicenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // workaround for Sqlite not supporting 'decimal' type
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
}

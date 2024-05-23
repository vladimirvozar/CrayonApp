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
        }
    }
}

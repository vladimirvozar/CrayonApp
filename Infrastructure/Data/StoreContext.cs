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

        // Software products and licenses related entities, available on Cloud Computing Provider
        #region 

        public DbSet<SoftwareProduct> SoftwareProducts { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<PerpetualLicense> PerpetualLicenses { get; set; }
        public DbSet<ConcurrentLicense> ConcurrentLicenses { get; set; }
        public DbSet<SubscriptionBasedLicense> SubscriptionBasedLicenses { get; set; }

        #endregion

        // Entities related to Customers, Accounts, their related purchased licenses and Order management
        #region 

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SoftwareLicense> SoftwareLicense { get; set; }
        public DbSet<SoftwareLicenseStatus> SoftwareLicenseStatuses { get; set; }
        public DbSet<LicenseStatus> LicenseStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

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

            // Seed data
            modelBuilder.SeedLicenseStatuses();
            modelBuilder.SeedCustomerWithAddressAndAccounts();
        }
    }
}

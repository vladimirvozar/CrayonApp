using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
             var jsonSerializationOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            if (!context.SoftwareProducts.Any())
            {
                var softwareProductJson = File.ReadAllText("../Infrastructure/Data/SeedData/softwareProducts.json");
                var softwareProducts = JsonSerializer.Deserialize<List<SoftwareProduct>>(softwareProductJson, jsonSerializationOptions);
                context.SoftwareProducts.AddRange(softwareProducts);
            }

            if (!context.PerpetualLicenses.Any())
            {
                var perpetualLicensesJson = File.ReadAllText("../Infrastructure/Data/SeedData/perpetualLicenses.json");
                var perpetualLicenses = JsonSerializer.Deserialize<List<PerpetualLicense>>(perpetualLicensesJson, jsonSerializationOptions);
                context.PerpetualLicenses.AddRange(perpetualLicenses);
            }

            if (!context.ConcurrentLicenses.Any())
            {
                var concurrentLicensesJson = File.ReadAllText("../Infrastructure/Data/SeedData/concurrentLicenses.json");
                var concurrentLicenses = JsonSerializer.Deserialize<List<ConcurrentLicense>>(concurrentLicensesJson, jsonSerializationOptions);
                context.ConcurrentLicenses.AddRange(concurrentLicenses);
            }

            if (!context.SubscriptionBasedLicenses.Any())
            {
                var subscriptionBasedLicensesJson = File.ReadAllText("../Infrastructure/Data/SeedData/subscriptionBasedLicenses.json");
                var subscriptionBasedLicenses = JsonSerializer.Deserialize<List<SubscriptionBasedLicense>>(subscriptionBasedLicensesJson, jsonSerializationOptions);
                context.SubscriptionBasedLicenses.AddRange(subscriptionBasedLicenses);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }

        internal static void SeedLicenseStatuses(this ModelBuilder builder)
        {
            builder.Entity<LicenseStatus>().HasData(
                new LicenseStatus { Id = 1, Code = "NA", Description = "Not Activated" },
                new LicenseStatus { Id = 2, Code = "ACT", Description = "Active" },
                new LicenseStatus { Id = 3, Code = "EXP", Description = "Expired" },
                new LicenseStatus { Id = 4, Code = "CA", Description = "Cancelled" }
                );
        }

        internal static void SeedCustomerWithAddressAndAccounts(this ModelBuilder builder)
        {
            // address
            builder.Entity<Address>().HasData(
                new Address
                { 
                    Id = 1,
                    City = "New York",
                    PostalCode = "21345",
                    State = "New York",
                    StreetAddressLine = "Main Street 32"
                });

            // customer
            builder.Entity<Customer>().HasData(
                new Customer 
                { 
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@mailinator.com",
                    Phone = "123-456",
                    AddressId = 1
                });

            // accounts
            builder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Name = "John's School account",
                    AccountType = AccountType.School,
                    CustomerId = 1
                });

            builder.Entity<Account>().HasData(
                new Account
                {
                    Id = 2,
                    Name = "John's Business account",
                    AccountType = AccountType.Business,
                    CustomerId = 1
                });

            builder.Entity<Account>().HasData(
                new Account
                {
                    Id = 3,
                    Name = "John's Premium account",
                    AccountType = AccountType.Premium,
                    CustomerId = 1
                });
        }
    }
}

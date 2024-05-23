using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
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
    }
}

using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Subscription based license - license that needs to be periodically renewed
    /// </summary>
    public class SubscriptionBasedLicense : License
    {
        public RenewalPeriod RenewalPeriod { get; set; }
    }
}

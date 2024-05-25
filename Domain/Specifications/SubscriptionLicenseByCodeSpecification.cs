using Domain.Entities;

namespace Domain.Specifications
{
    public class SubscriptionLicenseByCodeSpecification : BaseSpecification<License>
    {
        public SubscriptionLicenseByCodeSpecification(string code)
            : base(x => x.Code.ToLower() == code.ToLower() && x.IsSubscription)
        {

        }
    }
}

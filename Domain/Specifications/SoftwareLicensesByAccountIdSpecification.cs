using Domain.Entities;

namespace Domain.Specifications
{
    public class SoftwareLicensesByAccountIdSpecification : BaseSpecification<SoftwareLicense>
    {
        public SoftwareLicensesByAccountIdSpecification(int accountId)
            : base(x => x.AccountId == accountId)
        {
            AddInclude($"{nameof(SoftwareLicense.SoftwareLicenseStatuses)}.{nameof(SoftwareLicenseStatus.LicenseStatus)}");
        }
    }
}

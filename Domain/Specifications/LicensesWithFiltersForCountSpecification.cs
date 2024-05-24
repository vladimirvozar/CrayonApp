using Domain.Entities;

namespace Domain.Specifications
{
    public class LicensesWithFiltersForCountSpecification : BaseSpecification<License>
    {
        public LicensesWithFiltersForCountSpecification(LicensesSpecParams licensesParams)
            : base(x =>
                string.IsNullOrEmpty(licensesParams.SoftwareProductCode) ||
                x.SoftwareProduct.Code.ToLower().Contains(licensesParams.SoftwareProductCode))
        {

        }
    }
}

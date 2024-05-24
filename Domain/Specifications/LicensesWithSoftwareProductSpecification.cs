using Domain.Entities;

namespace Domain.Specifications
{
    public class LicensesWithSoftwareProductSpecification : BaseSpecification<License>
    {
        public LicensesWithSoftwareProductSpecification(LicensesSpecParams licensesParams)
            : base(x =>
                string.IsNullOrEmpty(licensesParams.SoftwareProductCode) ||
                x.SoftwareProduct.Code.ToLower().Contains(licensesParams.SoftwareProductCode))
        {
            AddInclude(x => x.SoftwareProduct);
            AddOrderBy(x => x.Name);
            ApplyPaging(licensesParams.PageSize * (licensesParams.PageIndex - 1), licensesParams.PageSize);

            if (!string.IsNullOrEmpty(licensesParams.Sort))
            {
                switch (licensesParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Price);
                        break;
                }
            }
        }
    }
}

using Domain.Entities;

namespace Domain.Specifications
{
    public class SoftwareProductsWithLicensesSpecification : BaseSpecification<SoftwareProduct>
    {
        public SoftwareProductsWithLicensesSpecification(string sort)
        {
            AddInclude(x => x.Licenses);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "codeAsc":
                        AddOrderBy(x => x.Code);
                        break;
                    case "codeDesc":
                        AddOrderByDescending(x => x.Code);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public SoftwareProductsWithLicensesSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Licenses);
        }
    }
}

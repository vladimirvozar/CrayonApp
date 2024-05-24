using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class SoftwareProductsWithLicensesSpecification : BaseSpecification<SoftwareProduct>
    {
        public SoftwareProductsWithLicensesSpecification()
        {
            AddInclude(x => x.Licenses);
        }

        public SoftwareProductsWithLicensesSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Licenses);
        }
    }
}

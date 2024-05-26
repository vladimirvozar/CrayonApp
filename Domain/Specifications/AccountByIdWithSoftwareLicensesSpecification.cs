using Domain.Entities;

namespace Domain.Specifications
{
    public class AccountByIdWithSoftwareLicensesSpecification : BaseSpecification<Account>
    {
        public AccountByIdWithSoftwareLicensesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.SoftwareLicenses);
        }
    }
}

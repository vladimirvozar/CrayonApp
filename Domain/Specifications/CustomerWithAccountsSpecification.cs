using Domain.Entities;

namespace Domain.Specifications
{
    public class CustomerWithAccountsSpecification : BaseSpecification<Customer>
    {
        public CustomerWithAccountsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Accounts);
        }
    }
}

using Domain.Entities;

namespace Domain.Specifications
{
    public class CustomersWithAddressesSpecification : BaseSpecification<Customer>
    {
        public CustomersWithAddressesSpecification()
        {
            AddInclude(c => c.Address);
        }
    }
}

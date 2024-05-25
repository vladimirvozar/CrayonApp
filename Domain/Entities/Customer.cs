using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [JsonIgnore]
        public List<Account> Accounts { get; set; }
    }
}

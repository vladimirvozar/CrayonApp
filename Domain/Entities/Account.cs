using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [JsonIgnore]
        public List<SoftwareLicense> SoftwareLicenses { get; set; }
    }
}

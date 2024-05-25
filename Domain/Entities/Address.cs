using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string StreetAddressLine { get; set; }
        [JsonIgnore]
        public List<Customer> Customers { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Base license class
    /// </summary>
    public abstract class License : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsSubscription { get; set; }
        [JsonIgnore]
        public SoftwareProduct SoftwareProduct { get; set; }
        public int SoftwareProductId { get; set; }
    }
}

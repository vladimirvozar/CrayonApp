using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class LicenseStatus : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<SoftwareLicenseStatus> SoftwareLicenseStatuses { get; set; }
    }
}

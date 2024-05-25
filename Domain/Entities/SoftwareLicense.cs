using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class SoftwareLicense : BaseEntity
    {
        public string SoftwareName { get; set; }
        public string SoftwareCode { get; set; }
        public string LicenseName { get; set; }
        public string LicenseCode { get; set; }
        public int Quantity { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ValidToDate { get; set; }
        public bool DoesNotExpire { get; set; }
        public bool AutoRenew { get; set; }
        public RenewalPeriod? RenewalPeriod { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [JsonIgnore]
        public List<SoftwareLicenseStatus> SoftwareLicenseStatuses { get; set; }
    }
}

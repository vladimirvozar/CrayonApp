namespace API.Dtos
{
    public class SoftwareLicenseDto
    {
        public string SoftwareName { get; set; }
        public string SoftwareCode { get; set; }
        public string LicenseName { get; set; }
        public string LicenseCode { get; set; }
        public int Quantity { get; set; }
        public string ValidFromDate { get; set; }
        public string ValidToDate { get; set; }
        public bool IsSubscription { get; set; }
        public string RenewalPeriod { get; set; }
        public string LicenseStatus { get; set; }
    }
}

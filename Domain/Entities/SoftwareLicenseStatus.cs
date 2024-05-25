namespace Domain.Entities
{
    public class SoftwareLicenseStatus
    {
        public int SoftwareLicenseId { get; set; }
        public SoftwareLicense SoftwareLicense { get; set; }
        public int LicenseStatusId { get; set; }
        public LicenseStatus LicenseStatus { get; set; }
        public DateTime SoftwareLicenseStatusDate { get; set; }
    }
}

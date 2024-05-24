namespace API.Dtos
{
    public class SoftwareProductDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<LicenseDto> Licenses { get; set; }
    }
}

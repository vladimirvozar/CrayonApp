namespace Domain.Entities
{
    public class SoftwareProduct : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<License> Licenses { get; set; }
    }
}

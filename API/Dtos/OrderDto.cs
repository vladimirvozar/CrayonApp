namespace API.Dtos
{
    public class OrderDto
    {
        public string SoftwareName { get; set; }
        public string SoftwareCode { get; set; }
        public string LicenseName { get; set; }
        public string LicenseCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public string OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public string AccountName { get; set; }
    }
}

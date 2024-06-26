﻿using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string SoftwareName { get; set; }
        public string SoftwareCode { get; set; }
        public string LicenseName { get; set; }
        public string LicenseCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [JsonIgnore]
        public SoftwareLicense SoftwareLicense { get; set; }
    }
}

using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Please enter software name")]
        public string SoftwareName { get; set; }

        [Required(ErrorMessage = "Please enter software code")]
        public string SoftwareCode { get; set; }

        [Required(ErrorMessage = "Please enter license code")]
        public string LicenseName { get; set; }

        [Required(ErrorMessage = "Please enter license code")]
        [MinLength(36, ErrorMessage = "License code must be 36 characters long.")]
        [StringLength(36, ErrorMessage = "License code must be 36 characters long.")]
        public string LicenseCode { get; set; }

        [Required(ErrorMessage = "Please enter quantity number")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive quantity number allowed.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter IsSubscription")]
        public bool IsSubscription { get; set; }

        [Required(ErrorMessage = "Please enter RenewalPeriod")]
        public RenewalPeriod? RenewalPeriod { get; set; }

        [Required(ErrorMessage = "Please enter price amount")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter customerId")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive quantity number allowed.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter accountId")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive quantity number allowed.")]
        public int AccountId { get; set; }
    }
}

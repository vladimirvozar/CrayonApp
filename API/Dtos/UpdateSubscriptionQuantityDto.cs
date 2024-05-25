using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateSubscriptionQuantityDto
    {
        [Required(ErrorMessage = "Please enter license code")]
        [MinLength(36, ErrorMessage = "License code must be 36 characters long.")]
        [StringLength(36, ErrorMessage = "License code must be 36 characters long.")]
        public string LicenseCode { get; set; }

        [Required(ErrorMessage = "Please enter quantity number")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive quantity number allowed.")]
        public int Quantity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class ActivateLicenseDto
    {
        [Required]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please enter license code")]
        [MinLength(36, ErrorMessage = "License code must be 36 characters long.")]
        [StringLength(36, ErrorMessage = "License code must be 36 characters long.")]
        public string LicenseCode { get; set; }

        [Required(ErrorMessage = "Please enter valid to date")]
        [DateGreaterThanTodayValidation]
        public string ValidToDate { get; set; }
    }
}

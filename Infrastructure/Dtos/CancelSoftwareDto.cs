using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class CancelSoftwareDto
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string SoftwareCode { get; set; }
    }
}

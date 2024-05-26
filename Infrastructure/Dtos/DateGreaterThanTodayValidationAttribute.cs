using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class DateGreaterThanTodayValidationAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Invalid date value provided";
        }

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {
            var successfulParse = DateTime.TryParse(objValue.ToString(), out var dateValue);

            if (!successfulParse || dateValue.Date < DateTime.UtcNow.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}

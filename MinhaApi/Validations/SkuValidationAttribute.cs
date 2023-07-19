using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Validations
{
    public class SkuValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) return ValidationResult.Success;

            if (!value.ToString().Contains("SKU")) return new ValidationResult($"The field '{validationContext.DisplayName}' is mandatory to have 'SKU...'.");

            return ValidationResult.Success;
        }
    }
}

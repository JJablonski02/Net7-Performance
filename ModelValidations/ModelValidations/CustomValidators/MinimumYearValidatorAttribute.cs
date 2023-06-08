using System.ComponentModel.DataAnnotations;

namespace ModelValidations.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should be less than {0}";
        public MinimumYearValidatorAttribute()
        {
        }
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format
                        (ErrorMessage ?? DefaultErrorMessage, MinimumYear)); // ?? if erromessage is null it returns defaulterrormessage
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}

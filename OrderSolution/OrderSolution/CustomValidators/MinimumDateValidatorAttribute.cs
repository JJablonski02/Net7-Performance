using System.ComponentModel.DataAnnotations;

namespace OrderSolution.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; }
        public DateTime MinimumDatetime { get; set; }
        public MinimumDateValidatorAttribute()
        {
            MinimumDatetime = Convert.ToDateTime(MinimumDatetime);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime orderTime = (DateTime)value;

                if (orderTime > MinimumDatetime)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDatetime.ToString("yyyy-MM-dd")));
                }

                //no errror
                return ValidationResult.Success;
            }
            return null;
        }
    }
}

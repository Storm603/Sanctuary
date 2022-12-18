using System.ComponentModel.DataAnnotations;
using Sanctuary.Web.Views.ViewModels;

namespace Sanctuary.Web.CustomValidationAttributes
{
    public class CheckBoxRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = (RegisterViewModel)validationContext.ObjectInstance;
            
            if (!instance.TermsConditions)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}

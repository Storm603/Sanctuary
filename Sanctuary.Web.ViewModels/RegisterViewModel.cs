using System.ComponentModel.DataAnnotations;
using Sanctuary.Web.ViewModels.CustomValidationAttributes;

namespace Sanctuary.Web.Views.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        [CheckBoxRequired(ErrorMessage = "Please agree with the Terms and Conditions before proceeding.")]
        public bool TermsConditions { get; set; }
    }
}

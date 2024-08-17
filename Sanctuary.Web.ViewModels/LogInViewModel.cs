using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Web.Views.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

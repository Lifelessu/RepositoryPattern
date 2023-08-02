using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_Relationship_.ModelView
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation do not match.")]
        public string? ConfirmPassword { get; set; }
        
    }
}

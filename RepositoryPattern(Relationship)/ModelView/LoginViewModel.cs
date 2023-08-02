using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_Relationship_.ModelView
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        //[DisplayName(nameof = "Remember me")]
        public bool RememberMe { get; set; }
    }
}

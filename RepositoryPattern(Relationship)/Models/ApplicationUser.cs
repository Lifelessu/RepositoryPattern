using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern_Relationship_.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        public string? Username { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }    
           
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RepositoryPattern_Relationship_.Models
{
    public class AddSellerItem
    {
        [Required]
        [DisplayName("Item Name")]
        public string? ItemName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string? Description { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
    }
}

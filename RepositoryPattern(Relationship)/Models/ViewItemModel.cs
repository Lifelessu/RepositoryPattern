using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RepositoryPattern_Relationship_.Models
{
    public class ViewItemModel
    {
        [Key]
        public int SellerId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public int ItemId { get; set; }
        [Required]
        [DisplayName("Item Name")]

        public string? ItemName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}

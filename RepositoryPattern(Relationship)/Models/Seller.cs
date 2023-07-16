using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_Relationship_.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string ? FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string ? LastName { get; set; }  

        //Item Model
        public ICollection<Item> ? Items { get; set; }

    }
}

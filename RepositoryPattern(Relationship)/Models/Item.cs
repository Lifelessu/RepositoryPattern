using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern_Relationship_.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [DisplayName("Item Name")]
        public string ? ItemName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string ? Description { get; set; }

        //Seller Model
        [ForeignKey("SellerId")]
        public int SellerId { get; set; }   
        public Seller ? Sellers { get; set; }
    }
}

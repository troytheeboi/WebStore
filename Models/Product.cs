using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdId { get; set; }
        [Required]
        public string ProdName { get; set; }
        [Required]  
        public float Price { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }

        
        public virtual Category category { get; set; }
        
        public virtual Supplier supplier { get; set; }


        public List<Review> reviews { get; set; }

        public List<ShoppingCart> shoppingCarts { get; set; }

        public List<Order> orders { get; set; }

    }
}

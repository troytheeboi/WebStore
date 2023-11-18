using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ProductEntity
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

        
        public virtual CategoryEntity category { get; set; }
        
        public virtual SupplierEntity supplier { get; set; }


        public List<ReviewEntity> reviews { get; set; }

        public List<ShoppingCartEntity> shoppingCarts { get; set; }

        public List<OrderEntity> orders { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        [Required]
        public string ProdName { get; set; }
        [Required]  
        public float Price { get; set; }


        [Required]
        public Category category { get; set; }
        [Required]
        public Supplier supplier { get; set; }

        
        public List<Review> reviews { get; set; }

        public List<ShoppingCart> shoppingCarts { get; set; }

        public List<Order> orders { get; set; }







        public Product(int id, string name, float price)
        {
            ProdId = id;
            ProdName = name;
            Price = price;
            
        }

        public Product() { 

        }
    }
}

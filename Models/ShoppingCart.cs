using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Product> products { get; set; }

        public ShoppingCart(int cartId, DateTime date,int customerID)
        {
            CartId = cartId;
            DateCreated = date;
            CustomerId = customerID;
        }

        public ShoppingCart() { }


    }
}

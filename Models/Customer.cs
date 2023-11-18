using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int Phone { get; set; }

        public List<Review> reviews { get; set; }

        public ShoppingCart cart { get; set; }

        public List<Order> orders { get; set; }

    }
}

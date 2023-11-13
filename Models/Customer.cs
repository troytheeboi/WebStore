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

        public Customer(int id, string first,string last, int phone)
        {
            CustomerId = id;
            FirstName = first;
            LastName = last;
            Phone = phone;
        }

        public Customer() { }

    }
}

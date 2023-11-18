using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int Phone { get; set; }

        public List<ReviewEntity> reviews { get; set; }

        public ShoppingCartEntity cart { get; set; }

        public List<OrderEntity> orders { get; set; }

    }
}

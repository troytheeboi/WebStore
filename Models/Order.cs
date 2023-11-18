using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public float Total { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        
        public Customer customer { get; set; }
        [Required]
        public Payment payment { get; set; }

        public List<Product> products { get; set; }

    }
}

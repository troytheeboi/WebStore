using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ShoppingCartEntity
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [ForeignKey("CustomerEntity")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        public List<ProductEntity> products { get; set; }

    }
}

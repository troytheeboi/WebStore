using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class ShoppingCartEntity:ParentEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }

        [ForeignKey("CustomerEntity")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        public List<ProductEntity> products { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class CategoryEntity
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string CatName { get; set; }
        [Required]
        public string CatDescription { get; set; }

        public virtual List<ProductEntity> Products { get; set; }

    }
}

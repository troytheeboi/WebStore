using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string CatName { get; set; }
        [Required]
        public string CatDescription { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class CategoryEntity:ParentEntity
    {
        [Required]
        public string CatName { get; set; }
        [Required]
        public string CatDescription { get; set; }

        public virtual List<ProductEntity> Products { get; set; }

    }
}

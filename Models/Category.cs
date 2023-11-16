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

        public List<Product> Products { get; set; }

        public Category(int id, string name,string desc) {
            
            CatId = id; 
            CatName = name;
            CatDescription = desc;

        }

        public  Category() { 
        }

        

    }
}

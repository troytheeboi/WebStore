using System.ComponentModel.DataAnnotations;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class ReviewEntity:ParentEntity
    {
        [Required]
        public DateTime ReviewTime { get; set;}
        [Required]
        public string Status { get; set; }
        public CustomerEntity customer {  get; set; }
        
        public ProductEntity product { get; set; }

    }
}

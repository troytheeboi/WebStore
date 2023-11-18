using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class ReviewEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public DateTime ReviewTime { get; set;}
        [Required]
        public string Status { get; set; }
        public CustomerEntity customer {  get; set; }
        
        public ProductEntity product { get; set; }

    }
}

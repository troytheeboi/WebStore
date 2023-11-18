using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public DateTime ReviewTime { get; set;}
        [Required]
        public string Status { get; set; }
        public Customer customer {  get; set; }
        
        public Product product { get; set; }

    }
}

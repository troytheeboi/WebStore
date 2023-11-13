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

        public Review(int id,DateTime time,string stat)
        {
            ReviewId = id;
            ReviewTime = time;
            Status = stat;
        }

        public Review() { }
    }
}

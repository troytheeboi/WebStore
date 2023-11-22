using System.ComponentModel.DataAnnotations;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class PaymentEntity:BaseEntity
    {
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }

    }
}

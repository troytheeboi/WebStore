using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }

        public Payment(int paymentId, float amount, DateTime paymentDate, string paymentMethod)
        {
            PaymentId = paymentId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }
        public Payment() { }
    }
}

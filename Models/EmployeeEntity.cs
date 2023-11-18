using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Salary { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; } 
        public BranchEntity branch { get; set; }

    }
}

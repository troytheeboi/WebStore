using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class EmployeeEntity:PersonEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Salary { get; set; }

        [ForeignKey("BranchEntity")]
        public int BranchId { get; set; } 
        public BranchEntity branch { get; set; }

    }
}

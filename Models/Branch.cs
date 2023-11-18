using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int capacity { get; set; }

        public List<Employee> employees { get; set; }

        [ForeignKey("Employee")]
        public int? ManagerID { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class BranchEntity
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int capacity { get; set; }

        public List<EmployeeEntity> employees { get; set; }

        [ForeignKey("Employee")]
        public int? ManagerID { get; set; }

    }
}

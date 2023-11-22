using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class BranchEntity: ParentEntity
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public int capacity { get; set; }

        public List<EmployeeEntity> employees { get; set; }

        public List<ProductEntity> products { get; set; }

        [ForeignKey("EmployeeEntity")]
        public int? ManagerID { get; set; }

    }
}

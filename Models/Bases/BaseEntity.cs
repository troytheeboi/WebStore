using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Bases
{
    public class BaseEntity : ParentEntity
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        [ForeignKey("EmployeeEntity")]
        public int EmployeeId { get; set; }


    }
}

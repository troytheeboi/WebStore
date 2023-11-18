using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class SupplierEntity
    {
        [Key]
        public int supplierId { get; set; }

        public string supplierName { get; set; }
        public int phoneNumber { get; set; }
        public string supplierAddress { get; set;}

    }
}

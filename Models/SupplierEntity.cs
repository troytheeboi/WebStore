using System.ComponentModel.DataAnnotations;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class SupplierEntity:ParentEntity
    {
        public string supplierName { get; set; }
        public int phoneNumber { get; set; }
        public string supplierAddress { get; set;}

    }
}

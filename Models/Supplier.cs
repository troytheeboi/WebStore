using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Supplier
    {
        [Key]
        public int supplierId { get; set; }

        public string supplierName { get; set; }
        public int phoneNumber { get; set; }
        public string supplierAddress { get; set;}

        public Supplier(int id,string name,int num,string add) {
            
            supplierId = id;
            supplierName = name;
            phoneNumber = num;
            supplierAddress = add;
        }

        public Supplier() { }


    }
}

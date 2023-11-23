using System.ComponentModel.DataAnnotations;
using WebStore.Models.Bases;

namespace WebStore.Models
{
    public class CustomerEntity:PersonEntity
    {
        public int Phone { get; set; }

        public List<ReviewEntity> reviews { get; set; }

        public ShoppingCartEntity cart { get; set; }

        public List<OrderEntity> orders { get; set; }

/*        public CustomerEntity(string firstName, string lastName,int phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
*/
    }
}

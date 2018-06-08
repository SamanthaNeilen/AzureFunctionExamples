using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AzureFunctionExample.ResourceAccess.DataAccess
{
    public class Person
    {
        public Person()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

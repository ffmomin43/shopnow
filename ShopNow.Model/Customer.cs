using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

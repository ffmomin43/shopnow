using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Expiry { get; set; }
    }
}

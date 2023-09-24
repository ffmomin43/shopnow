using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class ProductImage : IEntity<int>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string AltText { get; set; }

        public Product Product { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class ProductBullet: IEntity<int>
    {
        public int Id { get; set; }
        
        public string LineText { get; set; }

        public Product Product { get; set; }
    }
}

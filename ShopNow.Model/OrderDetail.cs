using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class OrderDetail: IEntity<int>
    {
        public int Id { get; set; }

        public int OrderedQuantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}

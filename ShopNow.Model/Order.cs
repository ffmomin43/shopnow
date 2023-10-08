using ShopNow.Model.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class Order:IEntity<int>
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

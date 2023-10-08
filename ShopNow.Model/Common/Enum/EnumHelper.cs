using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model.Common.Enum
{
    public enum  OrderStatus
    {
        Draft=10,
        Submitted=20,
        InProgress=30,
        FullFilled=40,
        Completed=50,
        Wishlisted=60
    }
}

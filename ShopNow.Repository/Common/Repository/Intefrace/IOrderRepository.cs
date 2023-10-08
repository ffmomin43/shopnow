using ShopNow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Repository.Common.Repository.Intefrace
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Order CheckOrderExistence(int customerId);

    }
}

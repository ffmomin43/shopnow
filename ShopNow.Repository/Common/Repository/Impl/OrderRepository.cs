using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.EF;
using System.Linq;

namespace ShopNow.Repository.Common.Repository.Impl
{
    public class OrderRepository : EFRepositoryBase<ECommerceContext, Order, int>, IOrderRepository
    {
        private readonly ECommerceContext _context;
        public OrderRepository()
        {
            _context = (ECommerceContext)this.m_dbContext;
        }

        public Order CheckOrderExistence(int customerId)
        {
            return _context.Orders
                .Include("Customer")
                .Where(x => x.Customer.Id == customerId &&
                            x.Status == Model.Common.Enum.OrderStatus.Draft)
                .SingleOrDefault();
        }
    }
}

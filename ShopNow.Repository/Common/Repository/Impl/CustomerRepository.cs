using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.EF;

namespace ShopNow.Repository.Common.Repository.Impl
{
    public class CustomerRepository : EFRepositoryBase<ECommerceContext, Customer, int>, ICustomerRepository
    {
    }
}

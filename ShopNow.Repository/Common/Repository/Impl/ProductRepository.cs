using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Interface;
using ShopNow.Repository.EF;

namespace ShopNow.Repository.Common.Repository.Impl
{
    public class ProductRepository: EFRepositoryBase<ECommerceContext,Product,int>, IProductRepository
    {
    }
}

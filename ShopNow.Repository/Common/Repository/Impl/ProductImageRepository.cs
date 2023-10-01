using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Interface;
using ShopNow.Repository.EF;

namespace ShopNow.Repository.Common.Repository.Impl
{
    public class ProductImageRepository : EFRepositoryBase<ECommerceContext, ProductImage, int>, IProductImageRepository
    {
    }
}

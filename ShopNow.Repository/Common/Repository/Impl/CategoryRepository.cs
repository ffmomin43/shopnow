using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.EF;

namespace ShopNow.Repository.Common.Repository.Impl
{
    public class CategoryRepository : EFRepositoryBase<ECommerceContext, Category, int>, ICategoryRepository
    {
    }
}

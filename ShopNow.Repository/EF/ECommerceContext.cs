using System.Data.Entity;

namespace ShopNow.Repository.EF
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext():base("ECommConnSt")
        {
                
        }

        public DbSet<Model.Product> Products { get; set; }

        public DbSet<Model.Category> Categories  { get; set; }
    }
}

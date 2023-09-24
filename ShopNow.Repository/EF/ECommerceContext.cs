using System.Data.Entity;

namespace ShopNow.Repository.EF
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext():base("ECommConnSt")
        {
                this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Model.Product> Products { get; set; }

        public DbSet<Model.Category> Categories  { get; set; }

        public DbSet<Model.ProductBullet> ProductBullets { get; set; }

        public DbSet<Model.ProductImage> ProductImages { get; set; }
    }
}

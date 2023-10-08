using ShopNow.Model;
using System.Data.Entity;

namespace ShopNow.Repository.EF
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext():base("ECommConnSt")
        {
                this.Configuration.LazyLoadingEnabled = false;
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories  { get; set; }

        public DbSet<ProductBullet> ProductBullets { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrdersDetails { get; set; }
    }
}

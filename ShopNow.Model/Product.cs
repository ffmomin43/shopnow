using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Model
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        public string ProductTitle { get; set; }

        public int RatingNumber { get; set; }

        public string ProductDescription { get; set; }

        public decimal ActualPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int AvailableQuantity { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductBullet> ProductBullets { get; set; }
    }
}

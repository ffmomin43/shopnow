using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNow.StoreFront.WebUI.Models
{
    public class ProductBoxItemModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public bool IsNewBadgeVisible { get; set; }

        public string ProductTitle { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
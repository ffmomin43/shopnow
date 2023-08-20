using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Repository.EF
{
    internal class ECommerceContext: DbContext
    {
        public ECommerceContext():base("ECommConnSt")
        {
                
        }


    }
}

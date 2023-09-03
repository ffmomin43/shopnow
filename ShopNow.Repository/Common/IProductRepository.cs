using ShopNow.Model;
using ShopNow.Repository.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Repository.Common
{
    internal interface IProductRepository: IRepository<Product, int>
    {

    }
}

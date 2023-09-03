using ShopNow.Model;
using ShopNow.Repository.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow.Repository
{
    internal interface ICategoryRepository: IRepository<Category, int>
    {
        void Add(Category category);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ShopNow.Repository.Common.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        DbSet<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TKey id);
        TKey Insert(TEntity model);
        bool Update(TEntity model);
        bool Remove(TKey id);
        bool Delete(TKey id);

    }
}

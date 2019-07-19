using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.InterfaceServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(bool complete = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool complete = false);
        TEntity Save(TEntity entity,ref string errorMessage);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        TEntity GetFirstOrDefaultById(long Id, bool complete = false);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool complete = false);
        void Dispose();
    }
}

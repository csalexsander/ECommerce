using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.InterfaceRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(bool AllIncludes = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false);
        void Update(TEntity entity);
        void OpenTransaction();
        void CommitTransaction();
        void RollBack();
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface IBaseApplication<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Save(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Dispose();
    }
}

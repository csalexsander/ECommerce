using ECommerce_Application.Interface;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Application
{
    public class BaseApplication<TEntity> : IDisposable, IBaseApplication<TEntity> where TEntity : class
    {
        protected readonly IBaseService<TEntity> _baseService;

        public BaseApplication(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        public TEntity Save(TEntity entity)
        {
            return _baseService.Save(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _baseService.AddRange(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseService.Count(predicate);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseService.Find(predicate);
        }

        public TEntity Get(long Id)
        {
            return _baseService.Get(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseService.GetAll();
        }

        public void Remove(TEntity entity)
        {
            _baseService.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _baseService.RemoveRange(entities);
        }
    }
}

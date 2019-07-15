using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class BaseService<TEntity> : IDisposable ,IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _baseRepository = repository;
        }

        public TEntity Save(TEntity entity)
        {
            var prop = entity.GetType().GetProperty("Id");
                        
            var Id = Convert.ToInt64(prop.GetValue(entity));

            if (Id == 0)
            {
                return _baseRepository.Add(entity);
            }

            _baseRepository.Update(entity);

            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.AddRange(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseRepository.Count(predicate);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public TEntity Get(long Id)
        {
            return _baseRepository.Get(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.RemoveRange(entities);
        }
    }
}

using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _baseRepository = repository;
        }

        public virtual TEntity Save(TEntity entity, ref string errorMessage)
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

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.AddRange(entities);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseRepository.Count(predicate);
        }

        public virtual void Dispose()
        {
            _baseRepository.Dispose();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool complete = false)
        {
            return _baseRepository.Find(predicate, complete);
        }

        public virtual IEnumerable<TEntity> GetAll(bool complete = false)
        {
            return _baseRepository.GetAll(complete);
        }

        public virtual void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.RemoveRange(entities);
        }
        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool complete = false)
        {
            return _baseRepository.GetFirstOrDefault(predicate, complete);
        }

        public virtual TEntity GetFirstOrDefaultById(long Id, bool complete = false)
        {
            return _baseRepository.GetFirstOrDefault(x => (long)x.GetType().GetProperty("Id").GetValue(x) == Id, complete);
        }
    }
}

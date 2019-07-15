using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly BaseContext _Context;
        private IDbContextTransaction _Transaction;

        public BaseRepository(BaseContext context)
        {
            _Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            var entityReturn = _Context.Set<TEntity>().Add(entity);
            Complete();
            return entityReturn.Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
            Complete();
        }

        private int Complete()
        {
            return _Context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(long Id)
        {
            return _Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
            Complete();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
            Complete();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Find(predicate).Count();
        }

        public void Update(TEntity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            Complete();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public void RollBack()
        {
            _Transaction.Rollback();
        }

        public void OpenTransaction()
        {
            _Transaction = _Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _Transaction.Commit();
        }
    }
}

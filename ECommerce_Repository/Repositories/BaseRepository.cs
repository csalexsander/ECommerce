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

        protected IQueryable<TEntity> GetQuery(bool AllIncludes)
        {
            var query = _Context.Set<TEntity>().AsQueryable();

            if (AllIncludes)
            {
                foreach (var property in _Context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                {
                    query = query.Include(property.Name);
                }
            }

            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var entityReturn = _Context.Set<TEntity>().Add(entity);
            Complete();
            return entityReturn.Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
            Complete();
        }

        protected int Complete()
        {
            return _Context.SaveChanges();
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false)
        {
            return GetQuery(AllIncludes).FirstOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false)
        {
            return GetQuery(AllIncludes).Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll(bool AllIncludes = false)
        {
            return GetQuery(AllIncludes).ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
            Complete();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
            Complete();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate, bool AllIncludes = false)
        {
            return Find(predicate, AllIncludes).Count();
        }

        public virtual void Update(TEntity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;

            Complete();
        }

        public virtual void Dispose()
        {
            _Context.Dispose();
        }

        public virtual void RollBack()
        {
            _Transaction.Rollback();
        }

        public void OpenTransaction()
        {
            _Transaction = _Context.Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            _Transaction.Commit();
        }
    }
}

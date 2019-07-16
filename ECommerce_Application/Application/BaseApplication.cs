using AutoMapper;
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
        private readonly IBaseService<TEntity> _baseService;
        protected readonly IMapper _Mapper;

        public BaseApplication(IBaseService<TEntity> baseService, IMapper mapper)
        {
            _Mapper = mapper;
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

        public void Dispose()
        {
            _baseService.Dispose();
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

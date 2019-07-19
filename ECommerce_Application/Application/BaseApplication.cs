using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Application
{
    public class BaseApplication<TEntity,TModel> : IDisposable, IBaseApplication<TEntity,TModel> where TEntity : class where TModel : class
    {
        private readonly IBaseService<TEntity> _baseService;
        protected readonly IMapper _Mapper;

        public BaseApplication(IBaseService<TEntity> baseService, IMapper mapper)
        {
            _Mapper = mapper;
            _baseService = baseService;
        }

        public IEnumerable<TModel> GetAll(bool complete = false)
        {
            var result = _baseService.GetAll(complete);

            return GetEnumerableTModel(result);
        }

        public TModel Save(TModel model, ref string errorMessage)
        {
            var entity = ModelToEntity(model);

            var result = _baseService.Save(entity, ref errorMessage);

            return EntityToModel(result);
        }

        public void AddRange(IEnumerable<TModel> models)
        {
            var entities = GetEnumerableTEntity(models);

            _baseService.AddRange(entities);
        }

        public void Remove(TModel model)
        {
            var entity = ModelToEntity(model);

            _baseService.Remove(entity);
        }

        public TModel GetFirstOrDefaultById(long Id, bool complete = false)
        {
            var result = _baseService.GetFirstOrDefaultById(Id, complete);

            return EntityToModel(result);
        }

        public void RemoveRange(IEnumerable<TModel> models)
        {
            var entities = GetEnumerableTEntity(models);

            _baseService.RemoveRange(entities);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

        protected IEnumerable<TEntity> GetEnumerableTEntity(IEnumerable<TModel> models)
        {
            return models.Select(x => _Mapper.Map<TEntity>(x));
        }
        protected IEnumerable<TModel> GetEnumerableTModel(IEnumerable<TEntity> entities)
        {
            return entities.Select(x => _Mapper.Map<TModel>(x));
        }

        protected TModel EntityToModel(TEntity entity)
        {
            return _Mapper.Map<TModel>(entity);
        }
        protected TEntity ModelToEntity(TModel model)
        {
            return _Mapper.Map<TEntity>(model);
        }

    }
}

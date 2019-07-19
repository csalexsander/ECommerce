using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface IBaseApplication<TEntity, TModel> where TEntity : class where TModel : class
    {
        IEnumerable<TModel> GetAll(bool complete = false);
        TModel Save(TModel model, ref string errorMessage);
        void AddRange(IEnumerable<TModel> models);
        void Remove(TModel model);
        TModel GetFirstOrDefaultById(long Id, bool complete = false);
        void RemoveRange(IEnumerable<TModel> models);
        void Dispose();
    }
}

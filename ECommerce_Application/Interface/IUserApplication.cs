using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface IUserApplication
    {
        IEnumerable<User> GetAllActives();
        bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErroMessage);
        User Save(User user);
        User GetFirstOrDefaultUserName(string UserName);
        User GetFirstOrDefaultId(long Id);
        IEnumerable<User> GetAll();
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        void Remove(User entity);
        void RemoveRange(IEnumerable<User> entities);
        int Count(Expression<Func<User, bool>> predicate);
        void Dispose();
    }
}

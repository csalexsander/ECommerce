using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.InterfaceServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAllActives();
        bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage);
        User Save(User user);
        User GetFirstOrDefaultByUserName(string UserName);
        User GetFirstOrDefaultById(long Id);
        User GetFirstOrDefaultById(long Id, bool complete);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllWithIncludes();
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        void Remove(User entity);
        void RemoveRange(IEnumerable<User> entities);
        int Count(Expression<Func<User, bool>> predicate);
        void Dispose();
    }
}

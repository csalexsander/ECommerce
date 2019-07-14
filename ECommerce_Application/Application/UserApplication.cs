using ECommerce_Application.Interface;
using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Application
{
    public class UserApplication : IUserApplication
    {
        readonly IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public int Count(Expression<Func<User, bool>> predicate)
        {
            return _userService.Count(predicate);
        }

        public void Dispose()
        {
            _userService.Dispose();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _userService.Find(predicate);
        }

        public User Get(long Id)
        {
            return _userService.Get(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public IEnumerable<User> GetAllActives()
        {
            return _userService.GetAllActives();
        }

        public bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType)
        {
            return _userService.LoginIsValid(userName, password, LoginType);
        }

        public void Remove(User entity)
        {
            _userService.Remove(entity);
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            _userService.RemoveRange(entities);
        }

        public User Save(User user)
        {
            return _userService.Save(user);
        }
    }
}

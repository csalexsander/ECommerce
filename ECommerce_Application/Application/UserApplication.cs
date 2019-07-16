using AutoMapper;
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
        protected readonly IUserService _userService;
        protected readonly IMapper _Mapper;

        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _Mapper = mapper;
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

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public IEnumerable<User> GetAllActives()
        {
            return _userService.GetAllActives();
        }

        public User GetFirstOrDefaultId(long Id)
        {
            return _userService.GetFirstOrDefaultById(Id);
        }

        public User GetFirstOrDefaultUserName(string UserName)
        {
            return _userService.GetFirstOrDefaultByUserName(UserName);
        }

        public bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage)
        {
            return _userService.LoginIsValid(userName, password, LoginType, ref ErrorMessage);
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

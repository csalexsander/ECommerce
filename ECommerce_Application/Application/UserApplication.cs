using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Application
{
    public class UserApplication : BaseApplication<User,UserModel>, IUserApplication
    {        
        readonly IUserService _userService;

        public UserApplication(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
        }

        public IEnumerable<UserModel> GetAllActives()
        {
            var result = _userService.GetAllActives();

            return GetEnumerableTModel(result);
        }

        public UserModel GetFirstOrDefaultByUsername(string UserName)
        {
            var result = _userService.GetFirstOrDefaultByUsername(UserName);

            return EntityToModel(result);
        }

        public bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage)
        {
            return _userService.LoginIsValid(userName, password, LoginType,ref ErrorMessage);
        }

        public bool UsernameisValid(string UserName, long Id, ref string ErrorMessage)
        {
            return _userService.UsernameisValid(UserName, Id,ref ErrorMessage);
        }
    }
}

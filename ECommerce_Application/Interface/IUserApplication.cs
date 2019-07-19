using ECommerce_Application.Models;
using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface IUserApplication : IBaseApplication<User,UserModel>
    {
        bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage);
        IEnumerable<UserModel> GetAllActives();
        UserModel GetFirstOrDefaultByUsername(string UserName);
        bool UsernameisValid(string UserName, long Id, ref string ErrorMessage);
    }
}

using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce_Domain.InterfaceServices
{
    public interface IUserService : IBaseService<User>
    {
        bool LoginIsValid(string userName, string password, Enumerators.LoginType LoginType, ref string ErrorMessage);
        IEnumerable<User> GetAllActives();
        User GetFirstOrDefaultByUsername(string UserName);
        bool UsernameisValid(string UserName, long Id, ref string ErrorMessage);
    }
}

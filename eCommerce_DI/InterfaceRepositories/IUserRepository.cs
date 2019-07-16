using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.InterfaceRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllActives();
        User GetUserComplete(long Id, Enumerators.LoginType loginType);
        User GetUserWithRole(long Id, string UserName = "");
    }
}

using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.InterfaceRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAllActives();
    }
}

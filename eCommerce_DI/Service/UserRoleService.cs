using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;

namespace ECommerce_Domain.Service
{
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        public UserRoleService(IUserRoleRepository repository) : base(repository)
        {
        }
    }
}

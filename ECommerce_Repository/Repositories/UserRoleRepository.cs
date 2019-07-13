using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(UserRoleContext context) : base(context)
        {

        }
    }
}

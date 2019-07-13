using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(UserAddressContext context) : base(context)
        {
        }
    }
}

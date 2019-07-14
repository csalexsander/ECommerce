using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class UserAddressService : BaseService<UserAddress>, IUserAddressService
    {
        public UserAddressService(IUserAddressRepository repository) : base(repository)
        {
        }
    }
}

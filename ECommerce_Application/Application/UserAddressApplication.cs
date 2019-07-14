using ECommerce_Application.Interface;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Application
{
    public class UserAddressApplication : BaseApplication<UserAddress>, IUserAddressApplication
    {
        public UserAddressApplication(IUserAddressService baseService) : base(baseService)
        {
        }
    }
}

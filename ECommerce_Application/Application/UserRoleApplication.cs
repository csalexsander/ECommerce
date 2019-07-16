using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Application
{
    public class UserRoleApplication : BaseApplication<UserRole>, IUserRoleApplication
    {
        readonly IUserRoleService roleService;
        public UserRoleApplication(IUserRoleService baseService, IMapper mapper) : base(baseService, mapper)
        {
            roleService = baseService;
        }

        public UserRole GetFirstOrDefaultById(long Id)
        {
            return roleService.GetFirstOrDefaultById(Id);
        }
    }
}

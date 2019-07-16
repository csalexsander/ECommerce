﻿using ECommerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Interface
{
    public interface IUserRoleApplication : IBaseApplication<UserRole>
    {
        UserRole GetFirstOrDefaultById(long Id);
    }
}

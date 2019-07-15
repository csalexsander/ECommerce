using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Application
{
    public class StateApplication : BaseApplication<State>, IStateApplication
    {
        public StateApplication(IStateService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}

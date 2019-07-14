using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class StateService : BaseService<State>, IStateService
    {
        public StateService(IStateRepository repository) : base(repository)
        {
        }
    }
}

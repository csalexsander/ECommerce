using ECommerce_Application.Interface;
using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Application
{
    public class ClientCreditCardApplication : BaseApplication<ClientCreditCard>, IClientCreditCardApplication
    {
        public ClientCreditCardApplication(IClientCreditCardService baseService) : base(baseService)
        {
        }
    }
}

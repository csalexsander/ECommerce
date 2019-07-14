using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Domain.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Service
{
    public class ClientCreditCardService : BaseService<ClientCreditCard>, IClientCreditCardService
    {
        public ClientCreditCardService(IClientCreditCardRepository repository) : base(repository)
        {
        }
    }
}

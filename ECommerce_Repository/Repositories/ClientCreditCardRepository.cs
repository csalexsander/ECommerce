﻿using ECommerce_Domain.Entities;
using ECommerce_Domain.InterfaceRepositories;
using ECommerce_Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Repository.Repositories
{
    public class ClientCreditCardRepository : BaseRepository<ClientCreditCard>, IClientCreditCardRepository
    {
        public ClientCreditCardRepository(BaseContext context) : base(context)
        {
        }
    }
}

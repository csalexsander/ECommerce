using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class Client : User
    {
        public ClientCreditCard CreditCard { get; set; }
    }
}

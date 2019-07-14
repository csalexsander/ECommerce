using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Commons.Enumerators;

namespace ECommerce_Domain.Entities
{
    public class ClientCreditCard : BaseEntity
    {
        public string Number { get; set; }
        public User User { get; set; }
        public string CardHolder { get; set; }
        public int SecurityCode { get; set; }
        public Enumerators.CreditCardBanner Banner { get; set; }
    }
}

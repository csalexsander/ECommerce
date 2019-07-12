using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Commons.Enumerators;

namespace ECommerce_Domain.Entities
{
    public class ClientCreditCard
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime CreationDate { get; set; }
        public int SecurityCode { get; set; }
        public Enumerators.CreditCardBanner Banner { get; set; }
        public bool Active { get; set; }
    }
}

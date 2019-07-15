using System;
using System.Collections.Generic;
using System.Text;
using ECommerce_Commons.Enumerators;

namespace ECommerce_Application.Models
{
    public class ClientCreditCardModel : BaseModel
    {
        public string Number { get; set; }
        public UserModel User { get; set; }
        public string CardHolder { get; set; }
        public int SecurityCode { get; set; }
        public Enumerators.CreditCardBanner Banner { get; set; }
    }
}

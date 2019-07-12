using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Commons.Enumerators
{
    public static class Enumerators
    {
        public enum AccessLevel
        {
            Client = 1,
            Internal,
            Administrator
        }

        public enum CreditCardBanner
        {
            MasterCard = 1,
            Visa,
            Elo,
            Alelo,
            ZueiraCard
        }

        public enum DiscountCouponMeasure
        {
            Percent = 1,
            FreeShipping,
            Value,
            FreeShippingAndPercent,
            FreeShippingAndValue
        }
    }
}

using ECommerce_Commons.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class DiscountCoupon
    {
        private decimal _Value;

        public long Id { get; set; }
        public string Identifier { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Active { get; set; } = true;
        public decimal Value { get { return GetValue(); } set { _Value = value; } }
        public Enumerators.DiscountCouponMeasure Measure { get; set; }
        public DateTime CreationDate { get; set; }

        private decimal GetValue()
        {
            switch (Measure)
            {
                case Enumerators.DiscountCouponMeasure.Percent:
                    return _Value / 100;
                case Enumerators.DiscountCouponMeasure.FreeShippingAndPercent:
                    return _Value / 100;
                default:
                    return _Value;
            }
        }
    }
}

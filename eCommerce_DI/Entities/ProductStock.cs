using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class ProductStock : BaseEntity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ProductColor Color { get; set; }
    }
}

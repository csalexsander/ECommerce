using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class ProductStock
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ProductColor Color { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}

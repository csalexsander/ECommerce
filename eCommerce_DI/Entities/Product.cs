using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public ProductBrand Brand { get; set; }
        public string Model { get; set; }
        public ProductDimension Dimensions { get; set; }
        public virtual List<ProductStock> Stock { get; set; }
    }
}

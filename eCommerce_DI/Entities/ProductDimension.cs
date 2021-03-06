﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class ProductDimension : BaseEntity
    {
        public Product Product { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Volume { get; set; }
        public string Weight { get; set; }
        public string Profundity { get; set; }
    }
}

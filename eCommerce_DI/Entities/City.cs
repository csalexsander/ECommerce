using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}

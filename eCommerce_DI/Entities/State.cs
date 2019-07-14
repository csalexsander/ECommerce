using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}

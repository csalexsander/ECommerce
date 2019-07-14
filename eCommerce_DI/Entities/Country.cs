using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<State> States { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}

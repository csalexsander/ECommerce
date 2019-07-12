using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class State
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}

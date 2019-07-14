using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}

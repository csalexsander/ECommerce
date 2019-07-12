using System;
using ECommerce_Commons.Enumerators;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class UserRole
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Enumerators.AccessLevel AccessLevel { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}

using System;
using ECommerce_Commons.Enumerators;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public Enumerators.AccessLevel AccessLevel { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}

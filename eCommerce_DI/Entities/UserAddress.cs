using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public bool Current { get; set; }
    }
}

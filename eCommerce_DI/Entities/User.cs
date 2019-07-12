using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserBlock { get; set; }
        public bool PasswordReset { get; set; }
        public string Email { get; set; }
        public UserAddress Address { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}

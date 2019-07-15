using ECommerce_Commons.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Application.Models
{
    public class UserRoleModel : BaseModel
    {
        public string Name { get; set; }
        public Enumerators.AccessLevel AccessLevel { get; set; }
        public virtual IEnumerable<UserModel> Users { get; set; }
    }
}

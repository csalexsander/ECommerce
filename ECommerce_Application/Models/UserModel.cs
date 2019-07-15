using ECommerce_Commons.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Application.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public UserRoleModel Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserBlock { get; set; }
        public bool PasswordReset { get; set; }
        public string Email { get; set; }
        public virtual List<UserAddressModel> Addresses { get; set; }
        public virtual List<ClientCreditCardModel> CreditCards { get; set; }

    }
}

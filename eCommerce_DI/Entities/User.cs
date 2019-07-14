using ECommerce_Commons.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserBlock { get; set; }
        public bool PasswordReset { get; set; }
        public string Email { get; set; }
        public virtual List<UserAddress> Addresses { get; set; }
        public virtual List<ClientCreditCard> CreditCards { get; set; }

        public bool HasAccess(Enumerators.LoginType LoginType)
        {
            if (!Active)
            {
                return Active;
            }

            switch (LoginType)
            {
                case Enumerators.LoginType.Site:
                    return Role.AccessLevel == Enumerators.AccessLevel.Client;
                case Enumerators.LoginType.API:
                    return Role.AccessLevel == Enumerators.AccessLevel.Client;
                case Enumerators.LoginType.Administrator:
                    return !(Role.AccessLevel == Enumerators.AccessLevel.Client);
                default:
                    return false;
            }
        }

    }
}

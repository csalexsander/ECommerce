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

        public bool HasAccess(Enumerators.LoginType LoginType, ref string ErrorMessage)
        {
            if (!Active)
            {
                ErrorMessage = "Your user is inactive";
                return Active;
            }

            bool isClient = Role.AccessLevel == Enumerators.AccessLevel.Client;
            bool isAdministrator = !(Role.AccessLevel == Enumerators.AccessLevel.Client);

            switch (LoginType)
            {
                case Enumerators.LoginType.Site:
                    ErrorMessage = !isClient ? "Unathorized login" : string.Empty;
                    return isClient;
                case Enumerators.LoginType.API:
                    ErrorMessage = !isClient ? "Unathorized login" : string.Empty;
                    return isClient;
                case Enumerators.LoginType.Administrator:
                    ErrorMessage = !isAdministrator ? "Unathorized login" : string.Empty;
                    return isAdministrator;
                default:
                    ErrorMessage = "Unathorized login";
                    return false;
            }
        }

    }
}

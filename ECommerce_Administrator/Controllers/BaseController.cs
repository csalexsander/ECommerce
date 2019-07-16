using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Commons.Constants;
using ECommerce_Commons.Enumerators;
using ECommerce_Depence_Injector.Authenticate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce_Administrator.Controllers
{
    public class BaseController : Controller
    {
        public long CodigoUsuario => Convert.ToInt64(HttpContext.GetClaimValue(Constant.ClaimType.UserId));
        public string NameOfUser => HttpContext.GetClaimValue(ClaimTypes.Name);
        public string Email => HttpContext.GetClaimValue(ClaimTypes.Email);
        public UserModel UserAuthenticated => JsonConvert.DeserializeObject<UserModel>(HttpContext.GetClaimValue(Constant.ClaimType.UserComplete));
        public Enumerators.AccessLevel AccessLevel => (Enumerators.AccessLevel)Convert.ToInt32(HttpContext.GetClaimValue(Constant.ClaimType.UserRole));
        public bool UserHasSession => !string.IsNullOrWhiteSpace(HttpContext.GetClaimValue(Constant.ClaimType.UserComplete));
    }
}
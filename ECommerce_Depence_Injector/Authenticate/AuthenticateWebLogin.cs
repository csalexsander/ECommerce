using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ECommerce_Application.Models;
using ECommerce_Commons.Constants;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace ECommerce_Depence_Injector.Authenticate
{
    public static class AuthenticateWebLogin
    {
        public static void AuthenticateWeb(this HttpContext _context, UserModel user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim(Constant.ClaimType.UserId, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(Constant.ClaimType.UserComplete, JsonConvert.SerializeObject(user)),
                    new Claim(Constant.ClaimType.UserRole, ((int)user.Role.AccessLevel).ToString())
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = user.Remember
            };

            _context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties);
        }

        public static string GetClaimValue(this HttpContext Context, string claimType)
        {
            try
            {
                return Context.User.FindFirst(claimType).Value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}

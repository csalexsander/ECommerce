using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Administrator.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (!UserHasSession)
            {
                return RedirectToAction("Logout", "Login");
            }

            return View();
        }
    }
}

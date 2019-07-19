using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Administrator.Controllers
{
    public class UserRoleController : BaseController
    {
        private IUserRoleApplication _application;

        public UserRoleController(IUserRoleApplication application, IMapper mapper)
        {
            _application = application;
        }

        // GET: UserRole
        public IActionResult Index()
        {
            if (!UserHasSession)
            {
                RedirectToAction(nameof(LoginController.Logout), "Login");
            }

            var Model = _application.GetAll();

            return View(Model);
        }

        public IActionResult Role(long id)
        {
            if (id == 0)
            {
                return View(new ReturnDefault(false, "User role not found"));
            }

            var userRole = _application.GetFirstOrDefaultById(id);

            if (userRole == null || userRole.Id == 0)
            {
                return View(new ReturnDefault(false, "User role not found"));
            }

            return Json(new ReturnDefault(true, "", userRole));
        }

        public IActionResult Save(UserRoleModel role)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(role.Name) || role.AccessLevel == 0)
                {
                    return Json(new ReturnDefault(false, "You have required fields not filled in"));
                }

                string successMessage = role.Id == 0 ? "Role added" : "edited role";

                string errorMessage = string.Empty;
                var result = _application.Save(role, ref errorMessage);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    return Json(new ReturnDefault(false, errorMessage));
                }

                return Json(new ReturnDefault(true, successMessage, result));
            }
            catch (Exception)
            {
                return Json(new ReturnDefault(false, "An error has occurred, Please contact the support team"));
            }
        }

        public IActionResult Delete(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    return View(new ReturnDefault(false, "User role not found"));
                }

                var role = _application.GetFirstOrDefaultById(Id);

                if (role == null)
                {
                    return View(new ReturnDefault(false, "User role not found"));
                }

                _application.Remove(role);

                return Json(new ReturnDefault(true, "Role removed"));
            }
            catch (Exception ex)
            {
                return Json(new ReturnDefault(false, "An error has occurred, Please contact the support team"));
            }
        }
    }
}
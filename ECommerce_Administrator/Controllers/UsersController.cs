using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce_Administrator.Controllers
{
    public class UsersController : BaseController
    {
        IUserApplication _application;
        IUserRoleApplication _roleApplication;

        public UsersController(IUserApplication application, IUserRoleApplication roleApplication)
        {
            _application = application;
            _roleApplication = roleApplication;
        }

        public IActionResult Index()
        {
            try
            {
                if (!UserHasSession)
                {
                    return RedirectToAction("Logout", "Login");
                }

                var users = _application.GetAll(true);

                return View(users);
            }
            catch (Exception ex)
            {
                //todo: Gerar tratamento de exceção e mensagem de erro
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult User(long Id)
        {
            try
            {
                if (!UserHasSession)
                {
                    return RedirectToAction("Logout", "Login");
                }

                var result = _application.GetFirstOrDefaultById(Id, true);

                var roles = _roleApplication.GetAll();

                var rolesSelect = roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, Disabled = !x.Active }).ToList();
                rolesSelect.Insert(0, new SelectListItem { Value = "", Text = "Select" });

                ViewBag.roles = rolesSelect;

                if (result == null)
                {
                    return View(new UserModel());
                }

                return View(result);
            }
            catch (Exception ex)
            {
                //todo: Gerar tratamento de exceção e mensagem de erro
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult SaveUser(UserModel user)
        {
            try
            {
                ModelState.Remove("Id");

                if (ModelState.IsValid)
                {
                    string errorMessage = string.Empty;
                    var userReturn = _application.Save(user, ref errorMessage);

                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        return Json(new ReturnDefault(false, errorMessage));
                    }

                    return Json(new ReturnDefault(true, "User saved", userReturn.Id));
                }

                return Json(new ReturnDefault(false, "An error has occurred, please contact the support team"));
            }
            catch (Exception ex)
            {
                return Json(new ReturnDefault(false, " An error has occurred, please contact the support team"));
            }
        }

        public IActionResult RemoveUser(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    return Json(new ReturnDefault(false, "User not found"));
                }

                var user = _application.GetFirstOrDefaultById(Id);

                if (user == null)
                {
                    return Json(new ReturnDefault(false, "User not found"));
                }

                _application.Remove(user);

                return Json(new ReturnDefault(true, "User removed"));
            }
            catch (Exception)
            {
                return Json(new ReturnDefault(false, "An error has occurred, please contact the support team"));
            }
        }
    }
}
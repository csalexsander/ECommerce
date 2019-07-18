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
        private IMapper _mapper;

        public UserRoleController(IUserRoleApplication application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        // GET: UserRole
        public IActionResult Index()
        {
            if (!UserHasSession)
            {
                RedirectToAction(nameof(LoginController.Logout), "Login");
            }

            var Model = _application.GetAll().Select(role => _mapper.Map<UserRoleModel>(role));

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

            var model = _mapper.Map<UserRoleModel>(userRole);

            return Json(new ReturnDefault(true, "", model));
        }

        public IActionResult Save(UserRoleModel user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Name) || user.AccessLevel == 0)
                {
                    return Json(new ReturnDefault(false, "You have required fields not filled in"));
                }

                string successMessage = user.Id == 0 ? "Role added" : "edited role";
                
                var result = _mapper.Map<UserRoleModel>(_application.Save(_mapper.Map<UserRole>(user)));

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
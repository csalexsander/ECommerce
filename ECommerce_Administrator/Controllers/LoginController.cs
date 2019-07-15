using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using ECommerce_Commons.Enumerators;
using ECommerce_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Administrator.Controllers
{
    public class LoginController : Controller
    {
        private IUserApplication _userApplication;
        private IMapper _mapper;

        public LoginController(IUserApplication userApplication, IMapper mapper)
        {
            _userApplication = userApplication;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string errorMessage = string.Empty;

                    bool authorized = _userApplication.LoginIsValid(model.UserName, model.Password, Enumerators.LoginType.Administrator, ref errorMessage);

                    errorMessage = authorized ? "The user is authenticated" : errorMessage;

                    return Json(new ReturnDefault(authorized, errorMessage));
                }

                return Json(new ReturnDefault(false, "Has required field not filled in", "Please check fields"));
            }
            catch (Exception ex)
            {
                //todo: new method to save exception in a text file
                return Json(new ReturnDefault(false, "Please contact the support team", "An error has occurred"));
            }
        }
    }
}
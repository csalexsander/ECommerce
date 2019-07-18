using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Application.Interface;
using ECommerce_Application.Models;
using ECommerce_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Administrator.Controllers
{
    public class UserController : BaseController
    {
        IUserApplication _application;
        IUserRoleApplication _userRoleApplication;
        IMapper _mapper;

        public UserController(IUserApplication application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (!UserHasSession)
            {
                return RedirectToAction("Logout", "Login");
            }

            var users = _application.GetAllWithIncludes().Select(x => _mapper.Map<UserModel>(x));

            return View(users);
        }

        //public IActionResult Details(long Id)
        //{
        //    if (!UserHasSession)
        //    {
        //        return RedirectToAction("Logout", "Login");
        //    }


        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvApp.Business.Interfaces;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Login()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]

        public IActionResult Login(AppUserLoginModel appUserLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckUser(appUserLoginModel.UserName, appUserLoginModel.Password))
                {
                    
                }

                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
            }
            return View(appUserLoginModel);
        }
    }
}

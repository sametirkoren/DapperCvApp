using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CvApp.Business.Interfaces;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public async Task<IActionResult> Login(AppUserLoginModel appUserLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckUser(appUserLoginModel.UserName, appUserLoginModel.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,appUserLoginModel.UserName),
                        new Claim(ClaimTypes.Role,"Admin"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent    = appUserLoginModel.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Home", new { @area = "Admin" });
                }

                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
            }
            return View(appUserLoginModel);
        }
    }
}

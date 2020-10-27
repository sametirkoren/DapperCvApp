using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.AppUserDtos;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private IAppUserService _appUserService;

        public HomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "bilgilerim";
            var userName = User.Identity.Name;
            var user = _appUserService.FindByName(userName);
            var appUserListDto = new AppUserUpdateModel
            {
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                Id = user.Id,
                ImageUrl = user.ImageUrl,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ShortDescription = user.ShortDescription,
               
            };
            return View(appUserListDto);
        }

        [HttpPost]

        public IActionResult Index(AppUserUpdateModel model)
        {
            TempData["active"] = "bilgilerim";
            if (ModelState.IsValid)
            {
                var updatedAppUser = _appUserService.GetById(model.Id);
                if(model.Picture != null)
                {
                    var imgName = Guid.NewGuid() + Path.GetExtension(model.Picture.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imgName ;
                    var stream = new FileStream(path, FileMode.Create);
                    model.Picture.CopyTo(stream);
                    updatedAppUser.ImageUrl = imgName;
                }

                updatedAppUser.LastName = model.LastName;
                updatedAppUser.FirstName = model.FirstName;
                updatedAppUser.PhoneNumber = model.PhoneNumber;
                updatedAppUser.ShortDescription = model.ShortDescription;
                updatedAppUser.Address = model.Address;
                updatedAppUser.Email = model.Email;

                _appUserService.Update(updatedAppUser);
                TempData["message"] = "İşleminiz başarı ile gerçekleşti";

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult ChangePassword()
        {
            var user = _appUserService.FindByName(User.Identity.Name);

            TempData["active"] = "sifre";
            return View(new AppUserPasswordDto { 
                Id = user.Id
            });;
        }

        [HttpPost]

        public IActionResult ChangePassword(AppUserPasswordDto model)
        {
            TempData["active"] = "sifre";

            if (ModelState.IsValid)
            {
                var updatedUser = _appUserService.FindByName(User.Identity.Name);
                updatedUser.Password = model.Password;
                _appUserService.Update(updatedUser);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.SocialMediaIconDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SocialMediaIconController : Controller
    {
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        public SocialMediaIconController(ISocialMediaIconService socialMediaIconService, IMapper mapper, IAppUserService appUserService)
        {
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "ikon";
            var user = _appUserService.FindByName(User.Identity.Name);

            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetByUserId(user.Id)));
        }

        public IActionResult Add()
        {
            TempData["active"] = "ikon";
            return View(new SocialMediaIconAddDto());
        }


        [HttpPost]
        public IActionResult Add(SocialMediaIconAddDto model)
        {
            TempData["active"] = "ikon";

            if (ModelState.IsValid)
            {
                var user = _appUserService.FindByName(User.Identity.Name);
                model.AppUserId = user.Id;
                _socialMediaIconService.Insert(_mapper.Map<SocialMediaIcon>(model));

                TempData["message"] = "Ekleme işlemi başarılı";

                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "ikon";
            return View(_mapper.Map<SocialMediaIconUpdateDto>(_socialMediaIconService.GetById(id)));
        }


        [HttpPost]
        public IActionResult Update(SocialMediaIconUpdateDto model)
        {
            TempData["active"] = "ikon";

            if (ModelState.IsValid)
            {
                var user = _appUserService.FindByName(User.Identity.Name);
                var updatedSocialMediaIcon = _socialMediaIconService.GetById(model.Id);


                updatedSocialMediaIcon.AppUserId = user.Id;
                updatedSocialMediaIcon.Icon = model.Icon;
                updatedSocialMediaIcon.Link = model.Link;

                _socialMediaIconService.Update(updatedSocialMediaIcon);


                TempData["message"] = "Güncelleme işlemi başarılı";

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var deletedIcon = _socialMediaIconService.GetById(id);
            _socialMediaIconService.Delete(deletedIcon);
            TempData["message"] = "Güncelleme işlemi başarılı";

            return RedirectToAction("Index");
        }


    }
}

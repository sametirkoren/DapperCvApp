using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CvApp.Web.ViewComponents
{
    public class AboutComponent : ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AboutComponent(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            //var userName = User.Identity.Name;
            //return View(_mapper.Map<AppUserListDto>(_appUserService.FindByName(userName)));

            var admin = _appUserService.GetAll().FirstOrDefault().Id;
            return View(_mapper.Map<AppUserListDto>(_appUserService.GetById(admin)));
        }
    }
}

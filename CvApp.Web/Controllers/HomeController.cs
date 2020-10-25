using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvApp.Business.Interfaces;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericService<Skill> _skillService;

        public HomeController(IGenericService<Skill> skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            return View(_skillService.GetAll());
        }
    }
}

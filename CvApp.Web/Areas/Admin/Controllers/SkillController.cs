using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.SkillDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly IGenericService<Skill> _genericSkillService;
        private readonly IMapper _mapper;

        public SkillController(IGenericService<Skill> genericSkillService, IMapper mapper)
        {
            _genericSkillService = genericSkillService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<SkillListDto>>(_genericSkillService.GetAll()));
        }


        public IActionResult Add()
        {
            TempData["active"] = "yetenek";
            return View(new SkillAddDto());
        }
        [HttpPost]
        public IActionResult Add(SkillAddDto model)
        {
            TempData["active"] = "yetenek";

            if (ModelState.IsValid)
            {
                _genericSkillService.Insert(_mapper.Map<Skill>(model));
                TempData["message"] = "Ekleme işleminiz başarılı";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "yetenek";
            return View(_mapper.Map<SkillUpdateDto>(_genericSkillService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Update(SkillUpdateDto model)
        {
            TempData["active"] = "yetenek";
            if (ModelState.IsValid)
            {
                var updatedSkill = _genericSkillService.GetById(model.Id);
                updatedSkill.Description = model.Description;
                _genericSkillService.Update(updatedSkill);
                TempData["message"] = "Güncelleme işleminiz başarılı";
                return RedirectToAction("Index");

            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            TempData["active"] = "yetenek";
            var deletedSkill = _genericSkillService.GetById(id);
            _genericSkillService.Delete(deletedSkill);
            TempData["message"] = "Silme işleminiz başarılı";
            return RedirectToAction("Index");
        }
    }
}

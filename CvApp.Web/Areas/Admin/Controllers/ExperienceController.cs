using System.Collections.Generic;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.ExperienceDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        private readonly IGenericService<Experience> _genericExperienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IGenericService<Experience> genericExperienceService, IMapper mapper)
        {
            _genericExperienceService = genericExperienceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            TempData["active"] = "deneyim";
            return View(_mapper.Map<List<ExperienceListDto>>(_genericExperienceService.GetAll()));
        }

        public IActionResult Add()
        {
            TempData["active"] = "deneyim";

            return View(new ExperienceAddDto());
        }

        [HttpPost]

        public IActionResult Add(ExperienceAddDto model)
        {
            
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                _genericExperienceService.Insert(_mapper.Map<Experience>(model));
                TempData["message"] = "Ekleme işleminiz başarı ile gerçekleşti.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Update (int id)
        {
            TempData["active"] = "deneyim";
            return View(_mapper.Map<ExperienceUpdateDto>(_genericExperienceService.GetById(id)));
        }

        [HttpPost]

        public IActionResult Update(ExperienceUpdateDto model)
        {
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                var updatedExperience = _genericExperienceService.GetById(model.Id);
                updatedExperience.Description = model.Description;
                updatedExperience.EndDate = model.EndDate;
                updatedExperience.StartDate = model.StartDate;
                updatedExperience.Title = model.Title;
                updatedExperience.SubTitle = model.SubTitle;
                _genericExperienceService.Update(updatedExperience);

                TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti.";
                return RedirectToAction("Index");
            
            }


            return View(model);
        
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "deneyim";
            var deletedExperience = _genericExperienceService.GetById(id);
            TempData["message"] = "Silme işleminiz başarı ile gerçekleşti.";
            return RedirectToAction("Index");


        }
    }
}

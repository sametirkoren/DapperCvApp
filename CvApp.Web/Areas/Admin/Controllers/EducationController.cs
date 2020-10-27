using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.EducationDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class EducationController : Controller
    {
        private readonly IGenericService<Education> _educationGenericService;
        private readonly IMapper _mapper;

        public EducationController(IGenericService<Education> educationGenericService, IMapper mapper)
        {
            _educationGenericService = educationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<List<EducationListDto>>(_educationGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            var deletedEntity = _educationGenericService.GetById(id);
            _educationGenericService.Delete(deletedEntity);
            TempData["message"] = "Silme işlemi başarılı";
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "egitim";
            return View(new EducationAddDto());
        }

        [HttpPost]

        public IActionResult Add(EducationAddDto model)
        {
            TempData["active"] = "egitim";

            if (ModelState.IsValid)
            {
                _educationGenericService.Insert(_mapper.Map<Education>(model));
                TempData["message"] = "Ekleme işlemi başarılı";
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<EducationUpdateDto>(_educationGenericService.GetById(id)));

        }

        [HttpPost]

        public IActionResult Update(EducationUpdateDto model)
        {
            TempData["active"] = "egitim";

            if (ModelState.IsValid)
            {
                var updatedEducation = _educationGenericService.GetById(model.Id);
                updatedEducation.Description = model.Description;
                updatedEducation.SubTitle = model.SubTitle;
                updatedEducation.Title = model.Title;
                updatedEducation.EndDate = model.EndDate;
                updatedEducation.StartDate = model.StartDate;
                
                _educationGenericService.Update(updatedEducation);
                TempData["message"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

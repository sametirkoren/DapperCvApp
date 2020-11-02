using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.InterestDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InterestController : Controller
    {
        private readonly IGenericService<Interest> _genericInterestSerivce;
        private readonly IMapper _mapper;

        public InterestController(IGenericService<Interest> genericInterestSerivce, IMapper mapper)
        {
            _genericInterestSerivce = genericInterestSerivce;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "hobi";
            return View(_mapper.Map<List<InterestListDto>>(_genericInterestSerivce.GetAll()));
        }

        public IActionResult Add()
        {
            TempData["active"] = "hobi";
            return View(new InterestAddDto());
        }

        [HttpPost]
        public IActionResult Add(InterestAddDto model)
        {
            TempData["active"] = "hobi";
            if (ModelState.IsValid)
            {
                _genericInterestSerivce.Insert(_mapper.Map<Interest>(model));
                TempData["message"] = "Ekleme işleminiz başarılı";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "hobi";
            return View(_mapper.Map<InterestUpdateDto>(_genericInterestSerivce.GetById(id)));

        }
        
        [HttpPost]
        public IActionResult Update(InterestUpdateDto model)
        {
            TempData["active"] = "hobi";
            if (ModelState.IsValid)
            {
                var updatedInterest = _genericInterestSerivce.GetById(model.Id);
                updatedInterest.Description = model.Description;
                _genericInterestSerivce.Update(updatedInterest);
                TempData["message"] = "Güncelleme işleminiz başarılı";
                return RedirectToAction("Index");


            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "hobi";

            var deletedInterest = _genericInterestSerivce.GetById(id);
            _genericInterestSerivce.Delete(deletedInterest);
            TempData["message"] = "Silme işleminiz başarılı";
            return RedirectToAction("Index");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.CertificationDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CertificationController : Controller
    {
        private readonly IGenericService<Certification> _certificationGenericService;
        private readonly IMapper _mapper;
        public CertificationController(IGenericService<Certification> certificationGenericService, IMapper mapper)
        {
            _certificationGenericService = certificationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sertifika";
            //var model = _certificationGenericService.GetAll();
            //List<CertificationListDto> list = new List<CertificationListDto>();
            //foreach (var item in model)
            //{
            //    CertificationListDto dto = new CertificationListDto();

            //    dto.Id = item.Id;
            //    dto.Description = item.Description;
            //    list.Add(dto);
            //}
            return View(_mapper.Map<List<CertificationListDto>>(_certificationGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "sertifika";
            var deletedEntity = _certificationGenericService.GetById(id);
            _certificationGenericService.Delete(deletedEntity);
            TempData["message"] = "Sertifika silindi";

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "sertifika";
            return View(new CertificationAddDto());
        }

        [HttpPost]
        public IActionResult Add(CertificationAddDto model)
        {
            TempData["active"] = "sertifika";

            if (ModelState.IsValid)
            {
                _certificationGenericService.Insert(_mapper.Map<Certification>(model));
                TempData["message"] = "Sertifika eklendi";
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "sertifika";
            return View(_mapper.Map<CertificationUpdateDto>(_certificationGenericService.GetById(id)));

        }

        [HttpPost]

        public IActionResult Update(CertificationUpdateDto model)
        {
            TempData["active"] = "sertifika";

            if (ModelState.IsValid)
            {
                var updatedCertification = _certificationGenericService.GetById(model.Id);
                updatedCertification.Description = model.Description;
                _certificationGenericService.Update(updatedCertification);
                TempData["message"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}

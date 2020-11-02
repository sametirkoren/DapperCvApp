using AutoMapper;
using CvApp.Business.Interfaces;
using CvApp.DTO.DTOs.SkillDtos;
using CvApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApp.Web.ViewComponents
{
    public class SkillComponent : ViewComponent
    {
        private readonly  IGenericService<Skill> _genericSkillService;
        private readonly IMapper _mapper;

        public SkillComponent(IGenericService<Skill> genericSkillService, IMapper mapper)
        {
            _genericSkillService = genericSkillService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<SkillListDto>>(_genericSkillService.GetAll()));
        }
    }
}

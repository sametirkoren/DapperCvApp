using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DTO.DTOs.SkillDtos
{
    public class SkillUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

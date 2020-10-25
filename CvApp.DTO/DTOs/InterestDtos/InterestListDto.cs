using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DTO.DTOs.InterestDtos
{
    public class InterestListDto : IDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}

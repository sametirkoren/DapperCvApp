﻿using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DTO.DTOs.ExperienceDtos
{
    public class ExperienceAddDto : IDto
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}

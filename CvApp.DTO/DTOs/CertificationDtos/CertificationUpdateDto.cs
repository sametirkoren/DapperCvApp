using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CvApp.DTO.DTOs.CertificationDtos
{
    public class CertificationUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}

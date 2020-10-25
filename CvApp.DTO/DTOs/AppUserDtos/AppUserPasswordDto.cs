using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DTO.DTOs.AppUserDtos
{
    public class AppUserPasswordDto : IDto
    {
        public int Id { get; set; }

        public string Password { get; set; }
    }
}

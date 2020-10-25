using CvApp.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DTO.DTOs.SocialMediaIconDtos
{
    public class SocialMediaIconUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}

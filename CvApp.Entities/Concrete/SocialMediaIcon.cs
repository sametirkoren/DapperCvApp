using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("SocialMediaIcons")]
    public class SocialMediaIcon : ITable
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public int AppUserId { get; set; }
    }
}

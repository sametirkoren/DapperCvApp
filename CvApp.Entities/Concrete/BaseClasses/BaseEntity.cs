using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete.BaseClasses
{
    public class BaseEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

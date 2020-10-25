using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete.BaseClasses
{
    public class BaseEntity2
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}

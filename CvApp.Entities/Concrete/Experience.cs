using CvApp.Entities.Concrete.BaseClasses;
using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Experiences")]
    public class Experience : BaseEntity ,  ITable
    {
      
    }
}

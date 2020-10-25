using CvApp.Entities.Concrete.BaseClasses;
using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Skills")]

    public class Skill  : BaseEntity2 , ITable
    {

    }
}

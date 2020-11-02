using CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DataAccess.Interfaces
{
    public interface ISocialMediaIconRepository
    {
        List<SocialMediaIcon> GetByUserId(int userId);
    }
}

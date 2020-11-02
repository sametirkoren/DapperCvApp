using CvApp.Business.Interfaces;
using CvApp.DataAccess.Interfaces;
using CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.Concrete
{
    public class SocialMediaIconManager : GenericManager<SocialMediaIcon>, ISocialMediaIconService
    {

        private readonly IGenericRepository<SocialMediaIcon> _genericRepository;
        private readonly ISocialMediaIconRepository _socialMediaIconRepository;
        public SocialMediaIconManager(IGenericRepository<SocialMediaIcon> genericRepository, ISocialMediaIconRepository socialMediaIconRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _socialMediaIconRepository = socialMediaIconRepository;
        }
        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _socialMediaIconRepository.GetByUserId(userId);
        }
    }
}

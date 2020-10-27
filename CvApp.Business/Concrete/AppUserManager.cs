using CvApp.Business.Interfaces;
using CvApp.DataAccess.Interfaces;
using CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericRepository<AppUser> _genericRepository;
        private readonly IAppUserRepository _appUserRepository;
        public AppUserManager(IGenericRepository<AppUser> genericRepository, IAppUserRepository appUserRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _appUserRepository = appUserRepository;
        }
        public bool CheckUser(string userName, string password)
        {
            return _appUserRepository.CheckUser(userName, password);
        }

        public AppUser FindByName(string userName)
        {
            return _appUserRepository.FindByName(userName);
            
        }
    }
}

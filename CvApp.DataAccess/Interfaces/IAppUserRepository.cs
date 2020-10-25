using CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DataAccess.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {

        /// <summary>
        /// Eğer user var ise true döner , yok ise false döner.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckUser(string userName, string password);
    }
}

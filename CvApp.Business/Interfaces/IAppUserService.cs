using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.Interfaces
{
    public interface IAppUserService
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

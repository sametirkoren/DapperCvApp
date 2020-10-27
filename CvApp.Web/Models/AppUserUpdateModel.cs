using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CvApp.Web.Models
{
    public class AppUserUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İsim gereklidir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres gereklidir")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email gereklidir")]
        public string Email { get; set; }


        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Telefon gereklidir")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Önyazı gereklidir")]
        public string ShortDescription { get; set; }

        public IFormFile Picture { get; set; }
    }
}

﻿using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("AppUsers")]
    public class AppUser : ITable
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }


        public string Email { get; set; }


        public string ImageUrl { get; set; }

        public string PhoneNumber { get; set; }


        public string UserName { get; set; }

        public string Password { get; set; }

        public string ShortDescription { get; set; }



    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.ViewModels
{
    public class UserRegistrationViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ValidationMessage { get; set; }
    }
}
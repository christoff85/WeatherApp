using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.ViewModels
{
    public class UserRegistrationViewModel : UserLoginViewModel
    {
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and password confirmation must match")]
        public string ConfirmPassword { get; set; }
    }
}
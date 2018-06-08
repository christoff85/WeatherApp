using System;
using System.Web.Mvc;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        

        public AccountController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel userVm)
        {
            userVm.ValidationMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var user = _userService.LoginUser(userVm.Username, userVm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }

                userVm.ValidationMessage = "Provided credentials are not correct";
            }
            return View(userVm);           
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationViewModel userVm)
        {
            userVm.ValidationMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var user = _userService.CreateUser(userVm.Username, userVm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }
                userVm.ValidationMessage = "Username already exists";
            }
            return View(userVm);
        }
    }
}
using System;
using System.Web.Mvc;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Resources;
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
            if (ModelState.IsValid)
            {
                var user = _userService.LoginUser(userVm.Username, userVm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("UserPanel", "Home");
                }

                ModelState.AddModelError(string.Empty, AccountControllerResources.LoginCredentialsNotCorrect);
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
            if (ModelState.IsValid)
            {
                var user = _userService.CreateUser(userVm.Username, userVm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("UserPanel", "Home");
                }
                ModelState.AddModelError(string.Empty, AccountControllerResources.UsernameAlreadyExists);
            }
            return View(userVm);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }
    }
}
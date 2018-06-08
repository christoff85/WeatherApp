using System;
using System.Web.Mvc;
using AutoMapper;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Domain.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWeatherService _weatherService;
        

        public HomeController(IUserService userService, IWeatherService weatherService, IWeatherProvider weatherProvider)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            
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
                var user = _userService.LoginUser(userVm.UserName, userVm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index");
                }
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
                var user = _userService.CreateUser(userVm.UserName, userVm.Password, userVm.IsAdmin);
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("Index");
                }
            }
            return View(userVm);
        }


        public ActionResult Index()
        {
            var model = _weatherService.GetLastStoredWeather(2643743);
            var result = _weatherService.GetCurrentWeather(model);

            var viewModel = Mapper.Map<Weather, WeatherViewModel>(result);

            return View(viewModel);
        }



        //public ActionResult AdminPanel()
        //{
        //    var model = _weatherService.GetLastStoredWeather(2643743);
        //    var result = _weatherService.GetCurrentWeather(model);

        //    var viewModel = Mapper.Map<Weather, WeatherViewModel>(result);

        //    return View(viewModel);
        //}
    }
}
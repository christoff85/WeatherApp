using System;
using System.Web.Mvc;
using AutoMapper;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Domain.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWeatherConditionsService _weatherService;
        

        public HomeController(IUserService userService, IWeatherConditionsService weatherService, IWeatherConditionsProvider weatherProvider)
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
        public ActionResult Login(User user)
        {
            var newUser = _userService.CreateUser(user);
            return RedirectToAction("Index");
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = _weatherService.GetById(1);
            var result = _weatherService.GetCurrentWeather(2643743);

            var viewModel = Mapper.Map<WeatherConditions, WeatherConditionsViewModel>(result);

            return View(viewModel);
        }
    }
}
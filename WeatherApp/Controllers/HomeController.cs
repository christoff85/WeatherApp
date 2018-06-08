using System;
using System.Web.Mvc;
using AutoMapper;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Domain.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }
    
        public ActionResult Index()
        {
            var user = GetCurrentUser();

            if (user == null)
                return RedirectToAction("Login", "Account");

            if (user.IsAdmin)
                return RedirectToAction("AdminPanel");

            var weather = _weatherService.GetLastStoredWeather(2643743);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(weather);

            return View(viewModel);
        }


        public ActionResult AdminPanel()
        {
            var user = GetCurrentUser();

            if (user == null)
                return RedirectToAction("Login", "Account");

            var weather = _weatherService.GetLastStoredWeather(2643743);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(weather);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminPanel(WeatherViewModel weatherVm)
        {
            var updatedWeather = _weatherService.GetCurrentWeather(weatherVm.Id, weatherVm.CityId);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(updatedWeather);

            return View(viewModel);
        }

        private User GetCurrentUser()
        {
            return (User) Session["User"];
        }
    }
}
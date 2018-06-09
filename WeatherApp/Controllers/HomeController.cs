using System;
using System.Configuration;
using System.Threading.Tasks;
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
    
        public ActionResult UserPanel()
        {
            var user = GetCurrentUser();

            if (user == null)
                return RedirectToAction("Login", "Account");

            if (user.IsAdmin)
                return RedirectToAction("AdminPanel");

            var cityId = int.Parse(ConfigurationManager.AppSettings["CityId"]);
            var weather = _weatherService.GetLastStoredWeather(cityId);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(weather);

            return View(viewModel);
        }


        public ActionResult AdminPanel()
        {
            var user = GetCurrentUser();

            if (user == null)
                return RedirectToAction("Login", "Account");

            var cityId = int.Parse(ConfigurationManager.AppSettings["CityId"]);
            var weather = _weatherService.GetLastStoredWeather(cityId);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(weather);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdminPanel(WeatherViewModel weatherVm)
        {
            var updatedWeather = await _weatherService.GetCurrentWeatherAsync(weatherVm.Id, weatherVm.CityId);
            var viewModel = Mapper.Map<Weather, WeatherViewModel>(updatedWeather);

            return View(viewModel);
        }

        private User GetCurrentUser()
        {
            return (User) Session["User"];
        }
    }
}
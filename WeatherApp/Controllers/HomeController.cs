using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models.DAL;
using WeatherApp.Models.Domain;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var service = new WeatherConditionsService(new SqlWeatherConditionsRepository(), new WeatherConditionsWebClient());
            var model = service.FindByCityId(1);
            var viewModel = new WeatherConditionsViewModel
            {
                Location = model.Location,
                Temperature = model.Temperature,
                MaxTemperature = model.MaxTemperature,
                MinTemperature = model.MinTemperature,
                Humidity = model.Humidity,
                Pressure = model.Pressure
            };

            return View(viewModel);
        }
    }
}
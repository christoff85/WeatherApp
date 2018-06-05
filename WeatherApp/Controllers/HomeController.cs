using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WeatherApp.Models.DAL;
using WeatherApp.Models.Domain;
using WeatherApp.Models.WebClient;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var service = new WeatherConditionsService(new SqlWeatherConditionsRepository(""), 
                new WeatherConditionsWebClient(
                    new OpenWeatherHttpClient(new HttpClient(), ConfigurationManager.AppSettings["BaseAddress"], ConfigurationManager.AppSettings["ApiKey"]),
                    new WeatherConditionsJsonDeserializer()));
            var result = service.GetConditionsFromWebClient(2643743);
            //var model = service.FindByCityId(1);

            var viewModel = Mapper.Map<WeatherConditions, WeatherConditionsViewModel>(result);

            return View(viewModel);
        }
    }
}
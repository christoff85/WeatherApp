using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using AutoMapper;
using WeatherApp.Data;
using WeatherApp.Data.Repositories;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Services;
using WeatherApp.ViewModels;
using WeatherApp.WebServices.WebClient;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            return RedirectToAction("Index");
        }

        // GET: Home
        public ActionResult Index()
        {
            WeatherConditions model;
            using (var context = new WeatherAppContext())
            {
                var service = new WeatherConditionsService(new SqlWeatherConditionsRepository(context));
                model = service.GetById(1);
            }
                
                    ;
            var webClient = new OpenWeatherWebClient(
                new JsonHttpClient(new HttpClient()), new OpenWeatherConditionsJsonDeserializer(), new OpenWeatherPathBuilder(ConfigurationManager.AppSettings["BaseAddress"], ConfigurationManager.AppSettings["ApiKey"]));
            var result = webClient.FindByCityId(2643743);

            var viewModel = Mapper.Map<WeatherConditions, WeatherConditionsViewModel>(model);

            return View(viewModel);
        }
    }
}
using System.Configuration;
using System.Net.Http;
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
            var service = new WeatherConditionsService(new SqlWeatherConditionsRepository(""))
                ;
            var webClient = new OpenWeatherWebClient(
                new JsonHttpClient(new HttpClient()), new OpenWeatherConditionsJsonDeserializer(), new OpenWeatherPathBuilder(ConfigurationManager.AppSettings["BaseAddress"], ConfigurationManager.AppSettings["ApiKey"]));
            var result = webClient.FindByCityId(2643743);
            //var model = service.FindByCityId(1);

            var viewModel = Mapper.Map<WeatherConditions, WeatherConditionsViewModel>(result);

            return View(viewModel);
        }
    }
}
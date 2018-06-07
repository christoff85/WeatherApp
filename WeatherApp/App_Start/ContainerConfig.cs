using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WeatherApp.Data;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.WebServices.WebClient;

namespace WeatherApp
{
    public class ContainerConfig
    {

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<WeatherAppContext>().InstancePerRequest();
            builder.RegisterType<HttpClient>().InstancePerRequest();
            builder.Register(o => new OpenWeatherPathBuilder(ConfigurationManager.AppSettings["BaseAddress"],
                ConfigurationManager.AppSettings["ApiKey"])).As<IWeatherPathBuilder>();

        var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
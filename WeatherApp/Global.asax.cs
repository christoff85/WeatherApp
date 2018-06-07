using System.Web.Mvc;
using System.Web.Routing;

namespace WeatherApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Initialize();
        }
    }
}

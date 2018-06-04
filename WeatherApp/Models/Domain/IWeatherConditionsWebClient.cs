using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsWebClient
    {
        WeatherConditions FindByCityId(int cityId);
    }
}

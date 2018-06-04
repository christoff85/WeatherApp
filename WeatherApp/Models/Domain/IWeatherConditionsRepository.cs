using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsRepository
    {
        WeatherConditions FindByCityId(int cityId);
    }
}
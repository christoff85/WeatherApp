using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.DAL
{
    public class WeatherConditionsWebClient : IWeatherConditionsWebClient
    {
        public WeatherConditions FindByCityId(int cityId)
        {
            return new WeatherConditions()
            {
                Location = "Warsaw",
                Temperature = 7,
                MaxTemperature = 15,
                MinTemperature = 2,
                Humidity = 81,
                Pressure = 1012
            };
        }
    }
}
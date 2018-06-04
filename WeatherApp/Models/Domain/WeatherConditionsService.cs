using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Domain
{
    public class WeatherConditionsService
    {
        private readonly IWeatherConditionsRepository _repository;

        public WeatherConditionsService(IWeatherConditionsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            return _repository.FindByCityId(cityId);
        }
    }
}
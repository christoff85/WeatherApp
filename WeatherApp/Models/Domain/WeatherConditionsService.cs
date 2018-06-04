using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Domain
{
    public class WeatherConditionsService
    {
        private readonly IWeatherConditionsRepository _repository;
        private readonly IWeatherConditionsWebClient _webClient;

        public WeatherConditionsService(IWeatherConditionsRepository repository, IWeatherConditionsWebClient webClient)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _webClient = webClient ?? throw new ArgumentNullException(nameof(webClient));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            return _repository.FindByCityId(cityId);
        }

        public WeatherConditions GetConditionsFromWebClient(int cityId)
        {
            return _webClient.FindByCityId(cityId);
        }
    }
}
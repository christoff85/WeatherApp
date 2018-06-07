using System;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public class WeatherConditionsService : IWeatherConditionsService
    {
        private readonly IWeatherConditionsRepository _repository;
        private readonly IWeatherConditionsProvider _provider;

        public WeatherConditionsService(IWeatherConditionsRepository repository, IWeatherConditionsProvider provider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public WeatherConditions GetById(int id)
        {
            return _repository.GetById(id);
        }

        public WeatherConditions GetLastStoredWeather(int cityId)
        {
            return _repository.FindByCityId(cityId);
        }

        public WeatherConditions GetCurrentWeather(int cityId)
        {
            return _provider.FindByCityId(cityId);
        }
    }
}
using System;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public class WeatherConditionsService : IWeatherConditionsService
    {
        private readonly IWeatherConditionsRepository _repository;

        public WeatherConditionsService(IWeatherConditionsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public WeatherConditions GetById(int id)
        {
            return _repository.GetById(id);
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            return _repository.FindByCityId(cityId);
        }
    }
}
using System;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        private readonly IWeatherProvider _provider;

        public WeatherService(IWeatherRepository repository, IWeatherProvider provider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public Weather GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Weather GetLastStoredWeather(int cityId)
        {
            return _repository.FindByCityId(cityId);
        }

        public Weather GetCurrentWeather(int cityId)
        {
            return _provider.FindByCityId(cityId);
        }
    }
}
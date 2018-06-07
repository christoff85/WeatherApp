﻿using System;
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
        private readonly IUnitOfWork _unitOfWork;

        public WeatherService(IWeatherRepository repository, IWeatherProvider provider, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Weather GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Weather GetLastStoredWeather(int cityId)
        {
            return _repository.GetSingleOrDefault(cityId);
        }

        public Weather GetCurrentWeather(Weather weather)
        {
            var updatedWeather = _provider.FindByCityId(weather.CityId);
            updatedWeather.Id = weather.Id;

            _repository.Update(updatedWeather, weather.Id);
            _unitOfWork.SaveChanges();

            return updatedWeather;
        }
    }
}
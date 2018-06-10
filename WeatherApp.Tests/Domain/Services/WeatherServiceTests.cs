using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Services;

namespace WeatherApp.Tests.Domain.Services
{
    [TestFixture]
    public class WeatherServiceTests
    {
        [Test]
        public void GetWeatherById_ExpectResultEqualsWeatherStub()
        {
            var repository = Substitute.For<IWeatherRepository>();
            var provider = Substitute.For<IWeatherProvider>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var id = 1;
            var expected = new Weather();
            repository.GetById(id).Returns(expected);

            var sut = new WeatherService(repository, provider, unitOfWork);
            var result = sut.GetById(id);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetLastStoredWeatherByCityId_ExpectResultEqualsWeatherStub()
        {
            var repository = Substitute.For<IWeatherRepository>();
            var provider = Substitute.For<IWeatherProvider>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var cityId = 1;
            var expected = new Weather();
            repository.GetSingleOrDefault(cityId).Returns(expected);

            var sut = new WeatherService(repository, provider, unitOfWork);
            var result = sut.GetLastStoredWeather(cityId);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetCurrentWeatherAsync_ExpectResultEqualsWeatherStub()
        {
            var repository = Substitute.For<IWeatherRepository>();
            var provider = Substitute.For<IWeatherProvider>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var cityId = 1;
            var weatherId = 10;
            var expected = new Weather();

            provider.FindByCityIdAsync(cityId).Returns(Task.FromResult(expected));
            
            var sut = new WeatherService(repository, provider, unitOfWork);
            var result = sut.GetCurrentWeatherAsync(weatherId, cityId).Result;

            repository.Received().Update(expected, weatherId);
            unitOfWork.Received().SaveChanges();

            Assert.AreEqual(expected, result);
        }
    }
}

using NUnit.Framework;
using System.Threading.Tasks;
using NSubstitute;
using WeatherApp.Domain.Models;
using WeatherApp.Providers.Abstractions.WeatherWebClient;
using WeatherApp.Providers.WeatherWebClient;

namespace WeatherApp.Tests.Providers.WeatherWebClient
{
    [TestFixture]
    public class OpenWeatherWebClientTests
    {
        [Test]
        public void FindByCityIdAsync_CompareWithExpectedStub_ExpectEquals()
        {
            var cityId = 1000;
            var fullPath = "fullPath";
            var content = "content";
            var expected = new Weather();

            var fakePathBuilder = Substitute.For<IWeatherPathBuilder>();
            fakePathBuilder.GetFullPath($"weather?id={cityId}&units=metric").Returns(fullPath);

            var fakeHttpClient = Substitute.For<IHttpClient>();
            fakeHttpClient.GetResponseContentAsync(fullPath).Returns(Task.FromResult(content));

            
            var fakeDeserializer = Substitute.For<IWeatherJsonDeserializer>();
            fakeDeserializer.Deserialize(content).Returns(expected);

            var sut = new OpenWeatherWebClient(fakeHttpClient, fakeDeserializer, fakePathBuilder);
            var result = sut.FindByCityIdAsync(cityId).Result;

            Assert.AreEqual(expected, result);
        }
    }
}

using NUnit.Framework;
using WeatherApp.Providers.WeatherWebClient;

namespace WeatherApp.Tests.Providers.WeatherWebClient
{
    [TestFixture]
    public class WeatherPathBuilderTests
    {
        [Test]
        public void BuildPathBasedOnGivenPathMembers_CompareWithManualBuild_ExpectEqual()
        {
            var baseAddress = @"http://myweathersite.com/";
            var apiKey = @"&APPID=someId";
            var query = @"weather?id=1";
            var expected = baseAddress + query + apiKey;

            var sut = new WeatherPathBuilder(baseAddress, apiKey);
            var result = sut.GetFullPath(query);
            
            Assert.AreEqual(expected, result);
        }
    }
}

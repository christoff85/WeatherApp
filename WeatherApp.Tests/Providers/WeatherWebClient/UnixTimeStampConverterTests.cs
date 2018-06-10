using NUnit.Framework;
using System;
using WeatherApp.Providers.WeatherWebClient;

namespace WeatherApp.Tests.Providers.WeatherWebClient
{
    [TestFixture]
    public class UnixTimeStampConverterTests
    {
        [Test]
        public void ConvertToDateTimeWithBaseDateAndTimestamp_ExpectEqualToManualConvert()
        {
            var baseDate = new DateTime(2000, 1, 1);
            double timestamp = 1232345566;
            var expected = baseDate.AddSeconds(timestamp).ToLocalTime();
        
            var sut = new UnixTimeStampConverter(baseDate);
            var result = sut.ConvertToLocalDateTime(timestamp);

            Assert.AreEqual(expected, result);
        }
    }
}

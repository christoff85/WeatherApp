using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using WeatherApp.Domain.Models;
using WeatherApp.Providers.Abstractions.WeatherWebClient;
using WeatherApp.Providers.WeatherWebClient;

namespace WeatherApp.Tests.Providers.WeatherWebClient
{
    [TestFixture]
    public class OpenWeatherJsonDeserializerTests
    {
        [Test]
        public void DeserializeJson_CompareEachExpectedValueWithResult_ExpectEqual()
        {
            var json = @"{
                            ""coord"":{ ""lon"":145.77,""lat"":-16.92},
                            ""weather"":[{""id"":802,""main"":""Clouds"",""description"":""scattered clouds"",""icon"":""03n""}],
                            ""base"":""stations"",
                            ""main"":{""temp"":25,""pressure"":1007,""humidity"":74,""temp_min"":20,""temp_max"":30},
                            ""visibility"":10000,
                            ""wind"":{""speed"":3.6,""deg"":160},
                            ""clouds"":{""all"":40},
                            ""dt"":1485790200,
                            ""sys"":{""type"":1,""id"":8166,""message"":0.2064,""country"":""AU"",""sunrise"":1485720272,""sunset"":1485766550},
                            ""id"":2172797,
                            ""name"":""Cairns"",
                            ""cod"":200
                        }";

            var lastUpdate = new DateTime(2018, 6, 1);
            var converter = Substitute.For<ITimeStampConverter>();
            converter.ConvertToLocalDateTime(1485790200).Returns(lastUpdate);

            var sut = new OpenWeatherJsonDeserializer(converter);
            var result = sut.Deserialize(json);

            Assert.AreEqual(2172797, result.CityId);
            Assert.AreEqual("Cairns", result.Location);
            Assert.AreEqual(25, result.Temperature);
            Assert.AreEqual(30, result.MaxTemperature);
            Assert.AreEqual(20, result.MinTemperature);
            Assert.AreEqual(74, result.Humidity);
            Assert.AreEqual(1007, result.Pressure);
            Assert.AreEqual(lastUpdate, result.LastUpdate);
        }
    }
}

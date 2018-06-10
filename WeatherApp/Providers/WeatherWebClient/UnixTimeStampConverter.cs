using System;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    internal class UnixTimeStampConverter : ITimeStampConverter
    {
        public DateTime ConvertToDateTime(double timestamp)
        {
            var converted = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            converted = converted.AddSeconds(timestamp).ToLocalTime();
            return converted;
        }
    }
}

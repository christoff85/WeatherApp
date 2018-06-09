using System;

namespace WeatherApp.WebServices.WebClient.Abstractions
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

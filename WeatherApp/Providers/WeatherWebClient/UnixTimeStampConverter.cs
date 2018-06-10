using System;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    internal class UnixTimeStampConverter : ITimeStampConverter
    {
        private DateTime _timeStampBaseDate;

        public UnixTimeStampConverter(DateTime timeStampBaseDate)
        {
            _timeStampBaseDate = timeStampBaseDate;
        }

        public DateTime ConvertToLocalDateTime(double timestamp)
        {
            var converted = _timeStampBaseDate.AddSeconds(timestamp).ToLocalTime();
            return converted;
        }
    }
}

using System;

namespace WeatherApp.Providers.Abstractions.WeatherWebClient
{
    public interface ITimeStampConverter
    {
        DateTime ConvertToLocalDateTime(double timestamp);
    }
}

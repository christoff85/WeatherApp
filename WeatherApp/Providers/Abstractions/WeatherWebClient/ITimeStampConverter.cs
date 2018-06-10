using System;

namespace WeatherApp.Providers.Abstractions.WeatherWebClient
{
    public interface ITimeStampConverter
    {
        DateTime ConvertToDateTime(double timestamp);
    }
}

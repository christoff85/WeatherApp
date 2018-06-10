using System;

namespace WeatherApp.Providers.WeatherWebClient.Abstractions
{
    public interface ITimeStampConverter
    {
        DateTime ConvertToDateTime(double timestamp);
    }
}

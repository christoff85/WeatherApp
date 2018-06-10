namespace WeatherApp.Providers.Abstractions.WeatherWebClient
{
    public interface IWeatherPathBuilder
    {
        string GetFullPath(string query);
    }
}
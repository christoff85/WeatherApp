namespace WeatherApp.Providers.WeatherWebClient.Abstractions
{
    public interface IWeatherPathBuilder
    {
        string GetFullPath(string query);
    }
}
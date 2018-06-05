namespace WeatherApp.Models.WebClient
{
    public interface IWeatherPathBuilder
    {
        string GetFullPath(string query);
    }
}
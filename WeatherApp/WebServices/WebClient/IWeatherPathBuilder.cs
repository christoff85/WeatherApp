namespace WeatherApp.WebServices.WebClient
{
    public interface IWeatherPathBuilder
    {
        string GetFullPath(string query);
    }
}
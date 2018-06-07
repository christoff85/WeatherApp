namespace WeatherApp.WebServices.WebClient.Abstractions
{
    public interface IWeatherPathBuilder
    {
        string GetFullPath(string query);
    }
}
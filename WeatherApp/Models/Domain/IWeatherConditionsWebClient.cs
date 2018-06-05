namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsWebClient
    {
        WeatherConditions FindByCityId(int cityId);
    }
}

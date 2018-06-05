namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsRepository
    {
        WeatherConditions FindByCityId(int cityId);
    }
}
namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsService
    {
        WeatherConditions FindByCityId(int cityId);
        WeatherConditions GetById(int id);
    }
}
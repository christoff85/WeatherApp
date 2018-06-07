namespace WeatherApp.Domain.Models
{
    public class Weather
    {
        public string Location { get; set; }
        public int CityId { get; set; }
        public int Temperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
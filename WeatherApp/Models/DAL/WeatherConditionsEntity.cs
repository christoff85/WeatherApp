namespace WeatherApp.Models.DAL
{
    public class WeatherConditionsEntity : IEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Temperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
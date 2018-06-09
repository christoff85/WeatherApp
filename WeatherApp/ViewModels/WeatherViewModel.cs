using System.ComponentModel;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Location { get; set; }

        public int Temperature { get; set; }

        [DisplayName("Minimum")]
        public int MinTemperature { get; set; }

        [DisplayName("Maximum")]
        public int MaxTemperature { get; set; }

        [DisplayName("Atm. Pressure")]
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
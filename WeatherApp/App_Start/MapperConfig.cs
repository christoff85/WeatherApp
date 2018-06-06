using AutoMapper;
using WeatherApp.Models.DAL;
using WeatherApp.Models.Domain;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<WeatherConditions, WeatherConditionsViewModel>();
                cfg.CreateMap<WeatherConditionsEntity, WeatherConditions>();
                cfg.CreateMap<WeatherConditions, WeatherConditionsEntity>();

                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>();
            });
        }
    }
}
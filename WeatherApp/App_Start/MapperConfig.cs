using AutoMapper;
using WeatherApp.Data.Entities;
using WeatherApp.Domain.Models;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Weather, WeatherViewModel>();
                cfg.CreateMap<WeatherConditionsEntity, Weather>();
                cfg.CreateMap<Weather, WeatherConditionsEntity>();

                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>();
            });
        }
    }
}
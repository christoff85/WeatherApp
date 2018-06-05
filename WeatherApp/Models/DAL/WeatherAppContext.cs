using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.DAL
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext() : base("WeatherAppContext")
        {
            
        }
        public DbSet<WeatherConditionsEntity> WeatherConditions { get; set; }

    }
}
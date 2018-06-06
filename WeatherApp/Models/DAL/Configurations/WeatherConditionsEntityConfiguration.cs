using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.DAL.Configurations
{
    public class WeatherConditionsEntityConfiguration : EntityTypeConfiguration<WeatherConditionsEntity>
    {
        public WeatherConditionsEntityConfiguration()
        {
            ToTable("WeatherConditions");
        }
    }
}
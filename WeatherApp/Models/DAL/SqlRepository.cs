using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.DAL
{
    public abstract class SqlRepository<TEntity> where TEntity : IEntity
    {
    }
}
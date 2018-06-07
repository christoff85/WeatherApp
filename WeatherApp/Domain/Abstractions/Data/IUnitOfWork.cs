using System;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

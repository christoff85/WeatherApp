using System;

namespace WeatherApp.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

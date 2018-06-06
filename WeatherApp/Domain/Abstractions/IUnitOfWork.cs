using System;

namespace WeatherApp.Domain.Abstractions
{
    internal interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

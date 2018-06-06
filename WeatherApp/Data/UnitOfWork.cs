using System.Data.Entity;
using WeatherApp.Domain.Abstractions;

namespace WeatherApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
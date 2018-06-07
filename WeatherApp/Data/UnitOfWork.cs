using WeatherApp.Domain.Abstractions.Data;

namespace WeatherApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherAppContext _context;

        public UnitOfWork(WeatherAppContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
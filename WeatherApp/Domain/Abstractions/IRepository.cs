using System.Collections.Generic;

namespace WeatherApp.Domain.Abstractions
{
    public interface IRepository<TModel>
    {
        void Add(TModel entity);
        void Delete(object id);
        void Delete(TModel domainModel);
        IEnumerable<TModel> Get();
        TModel GetById(int id);
        void Update(TModel domainModel);
        void SaveChanges();
    }
}
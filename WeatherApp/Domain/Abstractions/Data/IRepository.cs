using System.Collections.Generic;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IRepository<TModel>
    {
        void Create(TModel entity);
        void Delete(object id);
        void Delete(TModel domainModel);
        IEnumerable<TModel> Get();
        TModel GetById(int id);
        void Update(TModel domainModel);
    }
}
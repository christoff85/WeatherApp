using System.Collections.Generic;

namespace WeatherApp.Models.Domain
{
    public interface IRepository<TModel>
    {
        void Add(TModel entity);
        void Delete(object id);
        void Delete(TModel domainModel);
        IEnumerable<TModel> Get();
        TModel GetById(int id);
        void Update(TModel domainModel);
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WeatherApp.Models.DAL
{
    public abstract class SqlRepository<TEntity> where TEntity : class, IEntity
    {
        protected WeatherAppContext Context { get; }
        protected IDbSet<TEntity> Entities { get; }

        protected SqlRepository(WeatherAppContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }


        public virtual TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return Entities.ToList();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Entities.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
                Entities.Attach(entityToDelete);

            Entities.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Entities.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using WeatherApp.Domain.Abstractions.Data;

namespace WeatherApp.Data.Repositories
{
    public abstract class SqlBaseRepository<TModel, TEntity> : IRepository<TModel> where TEntity : class
    {
        protected WeatherAppContext Context { get; }
        protected IDbSet<TEntity> Entities { get; }

        protected SqlBaseRepository(WeatherAppContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public void Create(TModel model)
        {
            var entity = MapFromModel(model);
            Entities.Add(entity);
        }

        public virtual TModel GetById(int id)
        {
            var entity = Entities.Find(id);
            return MapFromEntity(entity);
        }

        public virtual IEnumerable<TModel> Get()
        {
            return Entities.Select(e => MapFromEntity(e)).ToList();
        }

        public virtual void Delete(object id)
        {
            var entity = Entities.Find(id);

            if (Context.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);

            Entities.Remove(entity);
        }

        public virtual void Update(TModel domainModel, int entityId)
        {
            var updated = MapFromModel(domainModel);

            TEntity existing = Entities.Find(entityId);
            Context.Entry(existing).CurrentValues.SetValues(updated);
        }

        protected TModel MapFromEntity(TEntity entity)
        {
            return Mapper.Map<TEntity, TModel>(entity);
        }

        protected TEntity MapFromModel(TModel model)
        {
            return Mapper.Map<TModel, TEntity>(model);
        }
    }
}
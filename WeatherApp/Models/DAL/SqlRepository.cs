namespace WeatherApp.Models.DAL
{
    public abstract class SqlRepository<TEntity> where TEntity : IEntity
    {
        protected WeatherAppContext Context { get; }

        protected SqlRepository(WeatherAppContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
        }
    }
}
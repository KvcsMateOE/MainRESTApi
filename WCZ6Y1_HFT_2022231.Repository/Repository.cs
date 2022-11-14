using System;
using System.Linq;

namespace WCZ6Y1_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected Repository(PublisherDbContext publisherDb)
        {
            PublisherDb = publisherDb;
            ;
        }

        public PublisherDbContext PublisherDb { get; }

        public void Create(T entity)
        {
            PublisherDb.Set<T>().Add(entity);
            PublisherDb.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return PublisherDb.Set<T>();
        }

        abstract public T ReadOne(int Id);

        public void Remove(T entity)
        {
            PublisherDb.Set<T>().Remove(entity);
            PublisherDb.SaveChanges();
        }

        abstract public void Update(T oldEntity, T newEntity);
    }
}

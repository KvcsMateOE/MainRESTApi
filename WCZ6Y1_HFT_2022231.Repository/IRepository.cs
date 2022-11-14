using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCZ6Y1_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        IQueryable<T> ReadAll();
        T ReadOne(int Id);
        void Update(T oldEntity, T newEntity);
        void Remove(T entity);
    }
}
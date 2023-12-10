using System;
using System.Linq;

namespace RetailApp.Data.Repository.Interfaces
{
    public interface IDbContextRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        
        T GetById(Guid id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(Guid id);

        void Save();
    }
}

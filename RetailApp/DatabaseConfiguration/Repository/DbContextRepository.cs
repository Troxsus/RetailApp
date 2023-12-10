using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Database;
using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.Data.Repository
{
    public class DbContextRepository<T> : IDbContextRepository<T> where T : class
    {
        private readonly RetailAppContext _context;
        
        private readonly DbSet<T> table;

        public DbContextRepository(RetailAppContext dbContext)
        {
            _context = dbContext;
            table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

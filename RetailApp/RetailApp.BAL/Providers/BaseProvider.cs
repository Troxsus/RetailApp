using System;
using System.Linq;
using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.BAL.Providers
{
    public abstract class BaseProvider<T> where T : class
    {
        protected readonly IDbContextRepository<T> _repository;

        public BaseProvider(IDbContextRepository<T> repository)
        {
            _repository = repository;
        }

        protected IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        protected T GetById(string entityId)
        {
            var orderIdAsGuid = Guid.Parse(entityId);

            return _repository.GetById(orderIdAsGuid);
        }

        protected bool Create(T entitiyToCreate)
        {
            _repository.Insert(entitiyToCreate);
            _repository.Save();

            return true;
        }

        protected bool Update(T entityToUpdate)
        {
            _repository.Update(entityToUpdate);
            _repository.Save();

            return true;
        }

        protected bool Delete(string entityId)
        {
            var entityIdAsGuid = Guid.Parse(entityId);

            _repository.Delete(entityIdAsGuid);
            _repository.Save();

            return true;
        }
    }
}

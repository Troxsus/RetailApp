using System;
using System.Linq;
using AutoMapper;
using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.BAL.Providers
{
    public abstract class BaseProvider<T> where T : class
    {
        protected readonly IMapper _mapper;
        protected IDbContextRepository<T> _repository;

        public BaseProvider(IMapper mapper)
        {
            _mapper = mapper;
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

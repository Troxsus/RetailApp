using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.Data.Providers.Interfaces
{
    public interface IDbRepositoryProvider
    {
        IDbContextRepository<T> GetRepository<T>() where T : class;
    }
}

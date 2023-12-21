using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RetailApp.Data.ConfigOptions;
using RetailApp.Data.ConfigOptions.Enums;
using RetailApp.Data.Database;
using RetailApp.Data.Providers.Interfaces;
using RetailApp.Data.Repository;
using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.Data.Providers
{
    public class DbRepositoryProvider : IDbRepositoryProvider
    {
        private readonly DbContext _dbContext;

        public DbRepositoryProvider(IOptions<RepositoryOptions> dbContext, IOptions<ConnectionStringOptions> connectionString)
        {
            _dbContext = GetDbContext(dbContext.Value.ContextType, connectionString);
        }

        public IDbContextRepository<T> GetRepository<T>() where T : class
        {
            return new DbContextRepository<T>(_dbContext);
        }

        private DbContext GetDbContext(string contextType, IOptions<ConnectionStringOptions> connectionString)
        {
            DbContext context;

            var parseResult = Enum.TryParse<DbContextTypes>(contextType, out var contextTypeAsEnum);
            var optionsBuilder = new DbContextOptionsBuilder();
            DbContextOptions options;

            switch (contextTypeAsEnum)
            {
                case DbContextTypes.RetailApp:
                    options = optionsBuilder.UseSqlServer(connectionString.Value.RetailApp).Options;
                    context = new RetailAppContext(options);
                    break;
                default:
                    options = optionsBuilder.UseSqlServer(connectionString.Value.RetailApp).Options;
                    context = new RetailAppContext(options);
                    break;
            }

            return context;
        }

    }
}

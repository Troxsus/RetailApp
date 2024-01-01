using Microsoft.EntityFrameworkCore;
using RetailApp.Data.ConfigOptions.Enums;
using RetailApp.Data.Database;
using RetailApp.Data.Repository;
using RetailApp.Data.Repository.Interfaces;

namespace RetailApp.Data.Providers
{
    public static class DbRepositoryProvider
    {
        public static string ConnectionString = "";

        public static IDbContextRepository<T> GetRepository<T>(DbContextTypes contextType) where T : class
        {
            var dbContext = GetDbContext(contextType);
            return new DbContextRepository<T>(dbContext);
        }

        private static DbContext GetDbContext(DbContextTypes contextType)
        {
            DbContext context;

            var optionsBuilder = new DbContextOptionsBuilder();
            DbContextOptions options;
            
            switch (contextType)
            {
                case DbContextTypes.RetailApp:
                    options = optionsBuilder.UseSqlServer(ConnectionString).Options;
                    context = new RetailAppContext(options);
                    break;
                default:
                    options = optionsBuilder.UseSqlServer(ConnectionString).Options;
                    context = new RetailAppContext(options);
                    break;
            }

            return context;
        }

    }
}

using RetailApp.Data.ConfigOptions.Enums;

namespace RetailApp.BAL.Providers.Interfaces
{
    public interface IProvider
    {
        void ConfigureProviderRepository(DbContextTypes contextTypes);
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using UnitOfWork.Interfaces;
using UnitOfWork.SqlServer;

namespace ApiClient.Config
{
    public static class DependenciesContainer
    {
        public static void AddMyDependencies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWorkSqlServer>();

            // Services
            // General
            services.AddScoped<IMecanicoService, MecanicoService>();
        }
    }
}

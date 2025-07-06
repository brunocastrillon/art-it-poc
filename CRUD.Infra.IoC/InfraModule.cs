using CRUD.Infra.IoC.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.IoC
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqliteContext(configuration);
            services.AddRepository();
            services.AddService();

            return services;
        }
    }
}
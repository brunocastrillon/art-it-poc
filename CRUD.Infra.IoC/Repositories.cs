using CRUD.Core.Domain.Contracts;
using CRUD.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.IoC
{
    public static class Repositories
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
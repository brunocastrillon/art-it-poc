using CRUD.Core.Application.AutoMapper;
using CRUD.Core.Application.Services.Cliente;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.IoC
{
    public static class Services
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
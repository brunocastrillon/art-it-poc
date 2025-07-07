using CRUD.Core.Application.AutoMapper;
using CRUD.Core.Application.Services.Cliente;
using CRUD.Core.Application.Services.TipoTelefone;
using CRUD.Core.Application.Services.Telefone;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.IoC
{
    public static class Services
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITipoTelefoneService, TipoTelefoneService>();
            services.AddScoped<ITelefoneService, TelefoneService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
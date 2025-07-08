using CRUD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.IoC.Databases
{
    public static class Sqlite
    {
        public static IServiceCollection AddSqliteContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("Sqlite"),
                    ob => ob.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ).EnableSensitiveDataLogging()
            );

            return services;
        }
    }
}
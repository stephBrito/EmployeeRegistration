using Employee.Infrastructure.Data.Repositories;
using Employee.Infrastructure.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure.Settings
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbService, DbService>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}

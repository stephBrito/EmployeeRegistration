using Employee.Application.UseCases.Employee;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Application.Extensions
{
    public static class UseCaseDependencyInjection
    {
        public static IServiceCollection AddAppEmployeeCase(this IServiceCollection services)
        {
            services.AddSingleton<IEmployeeUseCase, EmployeeUseCase>();

            return services;
        }
    }
}

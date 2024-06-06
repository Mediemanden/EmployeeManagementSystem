using Employee.Business.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICreateEmployeeCommand, CreateEmployeeCommand>();
        services.AddScoped<IGetEmployeeQuery, GetEmployeeQuery>();
        services.AddScoped<IGetEmployeesQuery, GetEmployeesQuery>();
        services.AddScoped<IUpdateEmployeeCommand, UpdateEmployeeCommand>();
        services.AddScoped<IDeleteEmployeeCommand, DeleteEmployeeCommand>();

        return services;
    }
}

using Employee.Business.Commands;
using Employee.Business.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
    {
        services.AddTransient<ICreateEmployeeCommand, CreateEmployeeCommand>();
        services.AddTransient<IGetEmployeeQuery, GetEmployeeQuery>();
        services.AddTransient<IGetEmployeesQuery, GetEmployeesQuery>();
        services.AddTransient<IUpdateEmployeeCommand, UpdateEmployeeCommand>();
        services.AddTransient<IDeleteEmployeeCommand, DeleteEmployeeCommand>();
        services.AddTransient<ISearchEmployeesQuery, SearchEmployeesQuery>();

        return services;
    }
}

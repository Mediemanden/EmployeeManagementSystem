using System.Runtime.Serialization;
using Employee.DataAccess.Clients;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;
using Employee.DataAccess.WebServices;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
    {
        // Add Db Context
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            options.UseSqlite("Filename=:memory:");
        });

        // Add Storage DI
        services.AddMemoryCache();

        services.AddScoped<IEmployeeStorage, EmployeeStorage>();
        services.AddScoped<IEmployeeStorage, EmployeeStorage>();
        services.AddScoped<IEmployeeStorageWithMemoryCache, EmployeeStorageWithMemoryCache>();

        // Add WebService Clients
        services.AddHttpClient<IdaClient>();
        services.AddTransient<ICompanyService, CompanyService>();

        return services;
    }
}

﻿using System.Runtime.Serialization;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
    {
        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            options.UseSqlite("Filename=:memory:");
        });

        services.AddMemoryCache();

        services.AddScoped<IEmployeeStorage, EmployeeStorage>();
        services.AddScoped<IEmployeeStorageWithMemoryCache, EmployeeStorageWithMemoryCache>();

        return services;
    }
}

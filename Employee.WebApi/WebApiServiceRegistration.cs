using Employee.Business;
using Microsoft.AspNetCore.Mvc;
using Employee.DataAccess;
using Employee.DataAccess.Options;

namespace Employee.WebApi;

public static class WebApiServiceRegistration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddOptionsWithValidateOnStart<WebServiceOptions>().BindConfiguration("WebServices");
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDependencies();
    }

    private static void AddDependencies(this IServiceCollection services)
    {
        services.AddBusinessDependencies();
        services.AddDataAccessDependencies();
    }

}

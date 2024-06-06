using Employee.Business;
using Employee.Business.Commands;

namespace Employee.WebApi;

public static class WebApiServiceRegistration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDependencies();
    }

    private static void AddDependencies(this IServiceCollection services)
    {
        services.AddBusinessDependencies();
    }

}

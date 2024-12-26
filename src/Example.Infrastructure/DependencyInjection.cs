using Example.Domain.Interfaces.Services;
using Example.Infrastructure.Services;

namespace Example.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHelloWorldService, HelloWorldService>();
        return services;
    }
}
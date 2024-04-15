using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigs(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IConfiguration, Config>();

        return serviceCollection;
    }
}
using Console.Scenarios;
using Console.Scenarios.LoginScenarios;
using Core.Services.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScenarios(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IScenario, LoginAdminScenario>();
        serviceCollection.AddScoped<IScenario, LoginAccountScenario>();
        serviceCollection.AddScoped<LoginScenario>();

        serviceCollection.AddScoped<AdminLoginService>();
        serviceCollection.AddScoped<AccountLoginService>();

        return serviceCollection;
    }
}
using Common.Extensions;
using Console.Extensions;
using Console.Scenarios.LoginScenarios;
using Core.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Console;

public static class Program
{
    public static async Task Main()
    {
        var connectionBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            Database = "postgres",
        };

        var collection = new ServiceCollection();

        collection
            .AddCore()
            .AddConfigs()
            .AddDatabase(connectionBuilder.ConnectionString)
            .AddScenarios();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();

        LoginScenario loginScenario = scope.ServiceProvider.GetRequiredService<LoginScenario>();

        while (true)
        {
            await loginScenario.Run();
        }
    }
}
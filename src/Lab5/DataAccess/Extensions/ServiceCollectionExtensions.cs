using Core.Repositories;
using DataAccess.Migrations;
using DataAccess.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection collection, string connectionString)
    {
        collection.AddDatabaseConnection(connectionString);
        collection.AddDatabaseMigrations(connectionString);

        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<IOperationRepository, OperationRepository>();

        return collection;
    }

    public static IServiceCollection AddDatabaseConnection(this IServiceCollection collection, string connectionString)
    {
        collection.AddNpgsqlDataSource(connectionString);

        return collection;
    }

    public static IServiceCollection AddDatabaseMigrations(this IServiceCollection collection, string connectionString)
    {
        collection
            .AddFluentMigratorCore()
            .ConfigureRunner(
                builder => builder
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .WithMigrationsIn(typeof(Initial).Assembly));

        return collection;
    }
}
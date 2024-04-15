using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceScopeExtensions
{
    public static void UseInfrastructureDataAccess(this IServiceScope scope)
    {
        if (scope == null) throw new ArgumentNullException(nameof(scope));

        IMigrationRunner migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        migrationRunner.MigrateUp();
    }
}
namespace EFCore.TableMapping.Shared.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseShared<T>(this IApplicationBuilder builder)
        where T : IRootDbContext
    {
        var migrator = DbMigrator.CreateMigrator(builder);
        migrator.Migrate<T>();

        var updater = DbUpdater.CreateUpdater(builder);
        updater.Update<T>();

        return builder;
    }
}

namespace EFCore.TableMapping.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShared<T>(this IServiceCollection services, string fileName)
        where T : RootDbContextBase
    {
        services.AddDbContext<T>(builder =>
        {
            var dataSource = Path.Combine(Environment.CurrentDirectory, $"{fileName}.sqlite");
            var connectionString = $"Data Source={dataSource};Foreign Keys=True";

            builder.UseSqlite(connectionString);

            // Sqlite - Enabling Foreign Key Support
            //
            // For detailed information read.
            // https://www.sqlite.org/foreignkeys.html
            //
            // Assuming the library is compiled with foreign key constraints enabled, it must still be enabled
            // by the application at runtime, using the PRAGMA foreign_keys command. For example:
            //
            // sqlite> PRAGMA foreign_keys = ON;
            //
            // Foreign key constraints are disabled by default (for backwards compatibility), so must be enabled
            // separately for each database connection.
            //
            // Note, however, that future releases of SQLite might change so that foreign key constraints
            // enabled by default. Careful developers will not make any assumptions about whether or not foreign keys
            // are enabled by default but will instead enable or disable them as necessary.
            //
            // The application can also use a PRAGMA foreign_keys statement to determine if foreign keys
            // are currently enabled. The following command-line session demonstrates this:
            //
            // sqlite> PRAGMA foreign_keys;
            // 0
            // sqlite> PRAGMA foreign_keys = ON;
            // sqlite> PRAGMA foreign_keys;
            // 1
            // sqlite> PRAGMA foreign_keys = OFF;
            // sqlite> PRAGMA foreign_keys;
            // 0
        });

        services.AddScoped<IRootDbContext>(sp => sp.GetRequiredService<T>());

        services.AddScoped<CreateBlogUseCase>();
        services.AddScoped<CreateRssBlogUseCase>();
        services.AddScoped<LoadBlogsUseCase>();
        services.AddScoped<LoadRssBlogsUseCase>();

        return services;
    }
}

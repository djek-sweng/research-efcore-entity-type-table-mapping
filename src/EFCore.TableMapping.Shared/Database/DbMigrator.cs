namespace EFCore.TableMapping.Shared.Database;

public class DbMigrator
{
    private readonly IApplicationBuilder _applicationBuilder;

    private DbMigrator(IApplicationBuilder applicationBuilder)
    {
        _applicationBuilder = applicationBuilder;
    }

    public static DbMigrator CreateMigrator(IApplicationBuilder applicationBuilder)
    {
        return new DbMigrator(applicationBuilder);
    }

    public void Migrate<T>()
        where T : IDbContext
    {
        using var scope = _applicationBuilder.ApplicationServices.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<T>();

        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}

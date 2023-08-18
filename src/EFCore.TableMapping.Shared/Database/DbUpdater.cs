namespace EFCore.TableMapping.Shared.Database;

public class DbUpdater
{
    private readonly IApplicationBuilder _applicationBuilder;

    private DbUpdater(IApplicationBuilder applicationBuilder)
    {
        _applicationBuilder = applicationBuilder;
    }

    public static DbUpdater CreateUpdater(IApplicationBuilder applicationBuilder)
    {
        return new DbUpdater(applicationBuilder);
    }

    public void Update<T>()
        where T : IRootDbContext
    {
        using var scope = _applicationBuilder.ApplicationServices.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<T>();

        if (false == ctx.Blogs.Any())
        {
            ctx.Blogs.AddRange(
                Blog.Create("Url 1"),
                Blog.Create("Url 2"));
            ctx.SaveChanges();
        }

        if (false == ctx.RssBlogs.Any())
        {
            ctx.RssBlogs.AddRange(
                RssBlog.Create("Url 3", "RssUrl 3"),
                RssBlog.Create("Url 4", "RssUrl 4"));
            ctx.SaveChanges();
        }
    }
}

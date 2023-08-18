namespace EFCore.TableMapping.Shared.UseCases;

public class CreateRssBlogUseCase
{
    private readonly IRootDbContext _ctx;

    public CreateRssBlogUseCase(IRootDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<RssBlog> ExecuteAsync(string url, string rssUrl, CancellationToken cancellationToken)
    {
        var rssBlog = RssBlog.Create(url, rssUrl);

        _ctx.RssBlogs.Add(rssBlog);
        await _ctx.SaveChangesAsync(cancellationToken);

        return rssBlog;
    }
}

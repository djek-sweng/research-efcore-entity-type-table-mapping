namespace EFCore.TableMapping.Shared.UseCases;

public class LoadRssBlogsUseCase
{
    private readonly IRootDbContext _ctx;

    public LoadRssBlogsUseCase(IRootDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IReadOnlyList<RssBlog>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _ctx.RssBlogs.ToListAsync(cancellationToken);
    }
}

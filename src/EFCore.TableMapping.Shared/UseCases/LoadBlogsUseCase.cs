namespace EFCore.TableMapping.Shared.UseCases;

public class LoadBlogsUseCase
{
    private readonly IRootDbContext _ctx;

    public LoadBlogsUseCase(IRootDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IReadOnlyList<Blog>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _ctx.Blogs.ToListAsync(cancellationToken);
    }
}

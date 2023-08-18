namespace EFCore.TableMapping.Shared.UseCases;

public class CreateBlogUseCase
{
    private readonly IRootDbContext _ctx;

    public CreateBlogUseCase(IRootDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Blog> ExecuteAsync(string url, CancellationToken cancellationToken)
    {
        var blog = Blog.Create(url);

        _ctx.Blogs.Add(blog);
        await _ctx.SaveChangesAsync(cancellationToken);

        return blog;
    }
}

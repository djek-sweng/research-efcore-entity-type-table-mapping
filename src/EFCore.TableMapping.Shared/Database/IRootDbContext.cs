namespace EFCore.TableMapping.Shared.Database;

public interface IRootDbContext : IDbContext
{
    DbSet<Blog> Blogs { get; }
    DbSet<RssBlog> RssBlogs { get; }
}

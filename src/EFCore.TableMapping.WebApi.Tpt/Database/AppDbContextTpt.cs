namespace EFCore.TableMapping.WebApi.Tpt.Database;

public class AppDbContextTpt : RootDbContextBase
{
    public AppDbContextTpt()
    {
    }

    public AppDbContextTpt(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.UseTptMappingStrategy();

            entity.ToTable("Blogs");
        });

        modelBuilder.Entity<RssBlog>(entity =>
        {
            entity.HasBaseType<Blog>();

            entity.ToTable("RssBlogs");
        });
    }
}

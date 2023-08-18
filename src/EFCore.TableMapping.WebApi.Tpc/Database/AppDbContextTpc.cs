namespace EFCore.TableMapping.WebApi.Tpc.Database;

public class AppDbContextTpc : RootDbContextBase
{
    public AppDbContextTpc()
    {
    }

    public AppDbContextTpc(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.UseTpcMappingStrategy();

            entity.ToTable("Blogs");
        });

        modelBuilder.Entity<RssBlog>(entity =>
        {
            entity.HasBaseType<Blog>();

            entity.ToTable("RssBlogs");
        });
    }
}

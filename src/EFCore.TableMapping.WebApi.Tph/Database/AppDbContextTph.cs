namespace EFCore.TableMapping.WebApi.Tph.Database;

public class AppDbContextTph : RootDbContextBase
{
    public AppDbContextTph()
    {
    }

    public AppDbContextTph(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.UseTphMappingStrategy();

            entity.ToTable("Blogs");

            entity.HasDiscriminator<string>("BlogType")
                .HasValue<Blog>(nameof(Blog))
                .HasValue<RssBlog>(nameof(RssBlog));
        });

        modelBuilder.Entity<RssBlog>(entity =>
        {
            entity.HasBaseType<Blog>();
        });
    }
}

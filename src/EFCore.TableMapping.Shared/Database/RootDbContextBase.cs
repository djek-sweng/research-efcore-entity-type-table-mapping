namespace EFCore.TableMapping.Shared.Database;

public abstract class RootDbContextBase : DbContext, IRootDbContext
{
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<RssBlog> RssBlogs { get; set; } = null!;

    protected RootDbContextBase()
    {
    }

    protected RootDbContextBase(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();

            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<RssBlog>(entity =>
        {
            entity.Property(e => e.RssUrl)
                .HasMaxLength(200)
                .IsRequired();
        });
    }
}

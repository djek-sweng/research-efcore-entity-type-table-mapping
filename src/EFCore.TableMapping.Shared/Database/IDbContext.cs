namespace EFCore.TableMapping.Shared.Database;

public interface IDbContext
{
    DatabaseFacade Database { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

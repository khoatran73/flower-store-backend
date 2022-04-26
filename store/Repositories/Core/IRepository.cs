namespace store.Repositories.Core;

public interface IRepository<TEntity, TKey> : IRepositoryCore<TEntity> where TEntity : IEntity<TKey>
{
    Task<TEntity> FindAsync(
        TKey id,
        bool includeDetails = false,
        bool isTracking = true,
        CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> GetAsync(
        TKey id,
        bool includeDetails = false,
        bool isTracking = true,
        CancellationToken cancellationToken = default (CancellationToken));

    Task DeleteAsync(TKey id, bool autoSave = false);
}
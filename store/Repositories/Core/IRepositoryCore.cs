using System.Linq.Expressions;

namespace store.Repositories.Core;

 public interface IRepositoryCore<TEntity> where TEntity : IEntityCore
  {
    Task<List<TEntity>> ToListAsync(
      bool includeDetails = false,
      bool isTracking = true,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<List<TEntity>> ToListAsync(
      ISpecification<TEntity> spec,
      bool includeDetails = false,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<PaginatedList<TEntity>> ToListAsync(
      PaginatedListQuery query,
      ISpecification<TEntity> spec = null,
      bool includeDetails = false,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> FirstOrDefaultAsync(
      ISpecification<TEntity> spec,
      bool includeDetails = false,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> FirstAsync(
      ISpecification<TEntity> spec,
      bool includeDetails = false,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> FindAsync(
      Expression<Func<TEntity, bool>> predicate,
      bool includeDetails = false,
      bool isTracking = true,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> GetAsync(
      Expression<Func<TEntity, bool>> predicate,
      bool includeDetails = false,
      bool isTracking = true,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<TEntity> AddAsync(TEntity entity, bool autoSave = false);

    Task AddRangeAsync(List<TEntity> entities, bool autoSave = false);

    Task AfterInsertAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false);

    Task UpdateRangeAsync(List<TEntity> entities, bool autoSave = false);

    Task DeleteAsync(TEntity entity, bool autoSave = false);

    Task BeforeDeleteAsync(TEntity entity);

    Task AfterDeleteAsync(TEntity entity);

    Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default (CancellationToken));

    Task IgnoreGlobalFilter();

    Task<IQueryable<TEntity>> Queryable();

    Task<IQueryable<TEntity>> WithDetailsAsync();

    Task<IQueryable<TEntity>> WithDetailsAsync(
      params Expression<Func<TEntity, object>>[] propertySelectors);

    Task<IQueryable<TEntity>> GetQueryableAsync();

    Task<IQueryable<TEntity>> SetGlobalFilters(IQueryable<TEntity> queryable);

    void IgnoreGlobalFilters();

    void ApplyGlobalFilters();
  }
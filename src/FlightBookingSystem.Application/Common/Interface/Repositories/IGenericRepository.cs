using System.Linq.Expressions;
using FlightBookingSystem.Domain.Common;

namespace FlightBookingSystem.Application.Common.Interface.Repositories;

public interface IGenericRepository<TEntity, TKey> where TEntity : AggregateRoot<TKey>
{
    IQueryable<TEntity> GetQueryableSet();

    Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Delete(TEntity entity);

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query);

    Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query);

    Task<List<T>> ToListAsync<T>(IQueryable<T> query);

    Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);

    Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector, CancellationToken cancellationToken = default);

    Task BulkUpdateAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector, CancellationToken cancellationToken = default);

    Task BulkMergeAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> idSelector, Expression<Func<TEntity, object>> updateColumnNamesSelector, Expression<Func<TEntity, object>> insertColumnNamesSelector, CancellationToken cancellationToken = default);

    Task BulkDeleteAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
}

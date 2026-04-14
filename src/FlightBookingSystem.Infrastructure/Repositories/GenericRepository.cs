using System.Linq.Expressions;
using FlightBookingSystem.Application.Common.Interface.Repositories;
using FlightBookingSystem.Domain.Common;
using FlightBookingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Infrastructure.Repositories;

public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : AggregateRoot<TKey>
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id.Equals(default(TKey)))
        {
            await AddAsync(entity, cancellationToken);
        }
        else
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<TEntity> GetQueryableSet()
    {
        return _context.Set<TEntity>();
    }

    public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.FirstOrDefaultAsync();
    }

    public async Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.SingleOrDefaultAsync();
    }

    public async Task<List<T>> ToListAsync<T>(IQueryable<T> query)
    {
        return await query.ToListAsync();
    }

    public async Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        //await _context.BulkInsertAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector, CancellationToken cancellationToken = default)
    {
        //await _context.BulkInsertAsync(entities, columnNamesSelector, cancellationToken: cancellationToken);
    }

    public async Task BulkUpdateAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector, CancellationToken cancellationToken = default)
    {
        //await _context.BulkUpdateAsync(entities, columnNamesSelector, cancellationToken: cancellationToken);
    }

    public async Task BulkDeleteAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        //await _context.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkMergeAsync(IReadOnlyCollection<TEntity> entities, Expression<Func<TEntity, object>> idSelector, Expression<Func<TEntity, object>> updateColumnNamesSelector, Expression<Func<TEntity, object>> insertColumnNamesSelector, CancellationToken cancellationToken = default)
    {
        //await _context.BulkMergeAsync(entities, idSelector, updateColumnNamesSelector, insertColumnNamesSelector, cancellationToken: cancellationToken);
    }
}

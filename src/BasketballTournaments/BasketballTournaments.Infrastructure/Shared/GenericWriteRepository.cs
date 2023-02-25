using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Shared;

public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericWriteRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task Delete(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public virtual async Task<Result<T>> GetById(object id, CancellationToken cancellationToken)
    {
        T? result = await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
        if (result is null)
        {
            return Result.Fail(new EntityNotFoundError());
        }

        return Result.Ok(result);
    }

    public virtual async Task Insert(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public virtual async Task Update(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}
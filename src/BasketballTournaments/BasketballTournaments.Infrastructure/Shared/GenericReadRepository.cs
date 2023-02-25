using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Shared;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericReadRepository(ApplicationDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async virtual Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }

    public async virtual Task<Result<T>> GetById(object id, CancellationToken cancellationToken)
    {
        T? result = await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
        if (result is null)
        {
            return Result.Fail(new EntityNotFoundError());
        }

        return Result.Ok(result);
    }
}

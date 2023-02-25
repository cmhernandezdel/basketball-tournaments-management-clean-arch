using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared;
using BasketballTournaments.Infrastructure.Shared.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace BaskteballTournaments.SeedWork;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
{
    private readonly DbSet<T> DbSet;

    public GenericReadRepository(ApplicationDbContext context)
    {
        DbSet = context.Set<T>();
    }

    public async virtual Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        return await DbSet.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }

    public async virtual Task<Result<T>> GetById(object id, CancellationToken cancellationToken)
    {
        T? result = await DbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
        if (result is null)
        {
            return Result.Fail(new EntityNotFoundError());
        }

        return Result.Ok(result);
    }
}

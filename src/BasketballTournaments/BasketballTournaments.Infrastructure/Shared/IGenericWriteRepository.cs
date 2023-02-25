using FluentResults;

namespace BasketballTournaments.Infrastructure.Shared;

public interface IGenericWriteRepository<T> where T : class
{
    public Task<Result<T>> GetById(object id, CancellationToken cancellationToken);

    public Task Insert(T entity, CancellationToken cancellationToken);

    public Task Update(T entity, CancellationToken cancellationToken);

    public Task Delete(T entity, CancellationToken cancellationToken);
}
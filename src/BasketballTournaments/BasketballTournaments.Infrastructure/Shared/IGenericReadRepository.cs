using FluentResults;

namespace BasketballTournaments.Infrastructure.Shared;

public interface IGenericReadRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);

    public Task<Result<T>> GetById(object id, CancellationToken cancellationToken);
}
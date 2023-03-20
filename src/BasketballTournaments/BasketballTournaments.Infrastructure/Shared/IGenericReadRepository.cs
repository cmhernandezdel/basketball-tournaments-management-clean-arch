using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Infrastructure.Shared;

public interface IGenericReadRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);

    public Task<Result<T>> GetById(object id, CancellationToken cancellationToken);

    public Task<IEnumerable<T>> Get(Specification<T> specification, CancellationToken cancellationToken);
}
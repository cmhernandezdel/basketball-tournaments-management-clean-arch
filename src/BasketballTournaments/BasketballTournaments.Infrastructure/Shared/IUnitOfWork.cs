using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Shared;

public interface IUnitOfWork<T> where T : DbContext
{
    Task<int> SaveChanges(CancellationToken cancellationToken);
}

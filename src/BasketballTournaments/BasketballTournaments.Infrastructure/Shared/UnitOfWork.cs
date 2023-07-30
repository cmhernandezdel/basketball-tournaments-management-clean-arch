using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Shared;

public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
{
    private readonly T _context;

    public UnitOfWork(T context)
    {
        _context = context;
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync();
    }
}

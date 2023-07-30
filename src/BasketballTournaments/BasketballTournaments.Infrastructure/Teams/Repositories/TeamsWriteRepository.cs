using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared;

namespace BasketballTournaments.Infrastructure.Teams.Repositories;

public sealed class TeamsWriteRepository : GenericWriteRepository<Team>, ITeamsWriteRepository
{
    public TeamsWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}

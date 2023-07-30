using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared;

namespace BasketballTournaments.Infrastructure.Teams.Repositories;

public sealed class TeamsReadRepository : GenericReadRepository<Team>, ITeamsReadRepository
{
    public TeamsReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}

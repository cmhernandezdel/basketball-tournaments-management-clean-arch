using BasketballTournaments.Domain.Players;
using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared;

namespace BasketballTournaments.Infrastructure.Players.Repositories;

public sealed class PlayersReadRepository : GenericReadRepository<Player>, IPlayersReadRepository
{
    public PlayersReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
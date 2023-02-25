using BasketballTournaments.Domain.Players;
using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Shared;

namespace BasketballTournaments.Infrastructure.Players.Repositories;

public sealed class PlayersWriteRepository : GenericWriteRepository<Player>, IPlayersWriteRepository
{
    public PlayersWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
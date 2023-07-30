using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Players.Repositories;
using BasketballTournaments.Infrastructure.Shared;
using BasketballTournaments.Infrastructure.Teams.Repositories;

namespace BasketballTournaments.Infrastructure.Teams.UnitsOfWork;

public interface ICreateTeamUnitOfWork : IUnitOfWork<ApplicationDbContext>
{
    ITeamsWriteRepository TeamsRepository { get; }

    IPlayersWriteRepository PlayersRepository { get; }
}

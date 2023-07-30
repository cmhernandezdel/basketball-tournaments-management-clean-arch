using BasketballTournaments.Infrastructure.Data;
using BasketballTournaments.Infrastructure.Players.Repositories;
using BasketballTournaments.Infrastructure.Shared;
using BasketballTournaments.Infrastructure.Teams.Repositories;

namespace BasketballTournaments.Infrastructure.Teams.UnitsOfWork;

public sealed class CreateTeamUnitOfWork : UnitOfWork<ApplicationDbContext>, ICreateTeamUnitOfWork
{
    private readonly ITeamsWriteRepository _teamsRepository;
    private readonly IPlayersWriteRepository _playersRepository;

    public CreateTeamUnitOfWork(ApplicationDbContext context) : base(context)
    {
        _teamsRepository = new TeamsWriteRepository(context);
        _playersRepository = new PlayersWriteRepository(context);
    }

    public ITeamsWriteRepository TeamsRepository => _teamsRepository;

    public IPlayersWriteRepository PlayersRepository => _playersRepository;
}

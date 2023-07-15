using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Teams;
using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.TournamentGames;

public sealed class TournamentGame : Entity
{
    public Guid HomeTeamId { get; }

    public Guid AwayTeamId { get; }

    public uint HomeTeamPoints { get; }

    public uint AwayTeamPoints { get; }

    public Stage Stage { get; }

    public Guid MostValuablePlayerId { get; }

    public Result<TournamentGame> Create(
        Team homeTeam,
        Team awayTeam,
        
    )

    public TournamentGame(Team homeTeam, Team awayTeam, uint homeTeamPoints, uint awayTeamPoints, Stage stage, Player mostValuablePlayer) : base()
    {
        HomeTeamId = homeTeam.Id;
        AwayTeamId = awayTeam.Id;
        HomeTeamPoints = homeTeamPoints;
        AwayTeamPoints = awayTeamPoints;
        Stage = stage;
        MostValuablePlayerId = mostValuablePlayer.Id;
    }
}

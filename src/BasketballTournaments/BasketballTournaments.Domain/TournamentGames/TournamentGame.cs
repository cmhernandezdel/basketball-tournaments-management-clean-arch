using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Domain.Tournaments;
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

    public Guid TournamentId { get; }

    public DateTime TimestampUtc { get; }

    public Result<TournamentGame> Create(
        Team homeTeam,
        Team awayTeam,
        uint homeTeamPoints,
        uint awayTeamPoints,
        Stage stage,
        Player mostValuablePlayer,
        Tournament tournament,
        DateTime timestampUtc)
    {
        Result validationResult = Result.Merge(
            Result.FailIf(homeTeam == awayTeam, "Home team cannot be the same as away team."),
            Result.FailIf(homeTeamPoints == awayTeamPoints, "A basketball game cannot end in a tie."),
            Result.FailIf(mostValuablePlayer.TeamId != homeTeam.Id && mostValuablePlayer.TeamId != awayTeam.Id, "The MVP is not on any of the two teams."),
            Result.FailIf(timestampUtc > tournament.EndTimestampUtc || timestampUtc < tournament.StartTimestampUtc, "Game is outside tournament dates.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new TournamentGame(homeTeam.Id, awayTeam.Id, homeTeamPoints, awayTeamPoints, stage, mostValuablePlayer.Id, tournament.Id, timestampUtc));
    }

    private TournamentGame(Guid homeTeamId, Guid awayTeamId, uint homeTeamPoints, uint awayTeamPoints, Stage stage, Guid mostValuablePlayerId, Guid tournamentId, DateTime timestampUtc) : base()
    {
        HomeTeamId = homeTeamId;
        AwayTeamId = awayTeamId;
        HomeTeamPoints = homeTeamPoints;
        AwayTeamPoints = awayTeamPoints;
        Stage = stage;
        MostValuablePlayerId = mostValuablePlayerId;
        TournamentId = tournamentId;
        TimestampUtc = timestampUtc;
    }
}

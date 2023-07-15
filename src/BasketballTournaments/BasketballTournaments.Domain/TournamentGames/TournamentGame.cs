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

    public Guid? TournamentId { get; private set; }

    public DateTime TimestampUtc { get; }

    public Result<TournamentGame> Create(
        Team homeTeam,
        Team awayTeam,
        uint homeTeamPoints,
        uint awayTeamPoints,
        Stage stage,
        Player mostValuablePlayer,
        DateTime timestampUtc)
    {
        Result validationResult = Result.Merge(
            Result.FailIf(homeTeam == awayTeam, "Home team cannot be the same as away team."),
            Result.FailIf(homeTeamPoints == awayTeamPoints, "A basketball game cannot end in a tie."),
            Result.FailIf(mostValuablePlayer.TeamId != homeTeam.Id && mostValuablePlayer.TeamId != awayTeam.Id, "The MVP is not on any of the two teams.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new TournamentGame(homeTeam.Id, awayTeam.Id, homeTeamPoints, awayTeamPoints, stage, mostValuablePlayer.Id, timestampUtc));
    }

    internal void SetTournament(Tournament? tournament)
    {
        TournamentId = tournament?.Id;
    }

    private TournamentGame(Guid homeTeamId, Guid awayTeamId, uint homeTeamPoints, uint awayTeamPoints, Stage stage, Guid mostValuablePlayerId, DateTime timestampUtc) : base()
    {
        HomeTeamId = homeTeamId;
        AwayTeamId = awayTeamId;
        HomeTeamPoints = homeTeamPoints;
        AwayTeamPoints = awayTeamPoints;
        Stage = stage;
        MostValuablePlayerId = mostValuablePlayerId;
        TournamentId = null;
        TimestampUtc = timestampUtc;
    }
}

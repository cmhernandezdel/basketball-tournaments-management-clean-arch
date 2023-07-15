using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Domain.TournamentGames;
using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.Tournaments;

public sealed partial class Tournament : Entity
{
    private readonly List<Team> _teams;
    private readonly List<TournamentGame> _games;

    public DateTime StartTimestampUtc { get; }

    public DateTime EndTimestampUtc { get; }

    public string Venue { get; }

    public IEnumerable<Team> Teams { get => _teams.AsEnumerable(); }

    public IEnumerable<TournamentGame> Games { get => _games.AsEnumerable(); }

    public Result<Tournament> Create(DateTime startTimestampUtc, DateTime endTimestampUtc, string venue)
    {
        string trimmedVenue = venue.Trim();

        Result validationResult = Result.Merge(
            Result.FailIf(startTimestampUtc >= endTimestampUtc, "Start date and time cannot be after end date and time."),
            Result.FailIf(string.IsNullOrEmpty(trimmedVenue), "Venue cannot be empty."),
            Result.FailIf(trimmedVenue.Length > MaxLengthVenue, $"Venue cannot exceed {MaxLengthVenue} characters.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new Tournament(startTimestampUtc, endTimestampUtc, trimmedVenue));
    }

    public void AddTeam(Team team)
    {
        if (!_teams.Contains(team))
        {
            _teams.Add(team);
        }
    }

    public Result AddGame(TournamentGame game)
    {
        Result validationResult = Result.Merge(
            Result.FailIf(game.TournamentId is not null, "Game belongs to another tournament."),
            Result.FailIf(game.TimestampUtc < StartTimestampUtc, "Game was before tournament start."),
            Result.FailIf(game.TimestampUtc > EndTimestampUtc, "Game was after tournament end."),
            Result.FailIf(_teams.FirstOrDefault(t => t.Id == game.HomeTeamId) is null, "Home team must be in the tournament."),
            Result.FailIf(_teams.FirstOrDefault(t => t.Id == game.AwayTeamId) is null, "Away team must be in the tournament.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        _games.Add(game);
        game.SetTournament(this);
        return Result.Ok();
    }

    private Tournament(DateTime startTimestampUtc, DateTime endTimestampUtc, string venue)
    {
        StartTimestampUtc = startTimestampUtc;
        EndTimestampUtc = endTimestampUtc;
        Venue = venue;
        _teams = new List<Team>();
        _games = new List<TournamentGame>();
    }
}

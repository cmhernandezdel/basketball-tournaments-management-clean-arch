using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.TournamentMatches;

public sealed class TournamentGame : Entity
{
    public Guid HomeTeamId { get; }

    public Guid AwayTeamId { get; }

    public uint HomeTeamPoints { get; }

    public uint AwayTeamPoints { get; }

    public Stage Stage { get; }

    public Guid MostValuablePlayerId { get; }
}

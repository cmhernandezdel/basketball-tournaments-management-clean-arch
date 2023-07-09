using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.TournamentTeams;

public sealed class TournamentTeam : Entity
{
    public Guid TeamId { get; }

    public Guid TournamentId { get; }

    public TournamentTeam(Guid teamId, Guid tournamentId)
    {
        TeamId = teamId;
        TournamentId = tournamentId;
    }
}

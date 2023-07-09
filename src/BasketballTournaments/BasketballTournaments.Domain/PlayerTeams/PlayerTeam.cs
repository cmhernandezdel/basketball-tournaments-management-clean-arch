using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.PlayerTeams;

public sealed class PlayerTeam : Entity
{
    public Guid PlayerId { get; }

    public Guid TeamId { get; }

    public PlayerTeam(Guid playerId, Guid teamId)
    {
        PlayerId = playerId;
        TeamId = teamId;
    }
}

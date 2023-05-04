using BasketballTournaments.Application.Shared.Converters;
using BasketballTournaments.Application.Shared.Queries;
using static BasketballTournaments.Domain.Players.Player;

namespace BasketballTournaments.Application.Players.Queries;

public sealed class PlayersFilter : IQueryStringFilter
{
    [FilterSpecification(typeof(SpanishIdSpecification), typeof(SpanishIdConverter))]
    public string? PlayerId { get; set; }

    [FilterSpecification(typeof(TeamSpecification))]
    public Guid? TeamId { get; set; }

    public PlayersFilter()
    {
        // Required because of .NET pipeline limitations
    }

    public PlayersFilter(string? playerId, Guid? teamId)
    {
        PlayerId = playerId;
        TeamId = teamId;
    }
}

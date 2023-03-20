using BasketballTournaments.Application.Shared.Queries;
using static BasketballTournaments.Domain.Players.Player;

namespace BasketballTournaments.Application.Players.Queries;

public sealed class PlayersFilter : IQueryStringFilter
{
    [FilterSpecification(typeof(SpanishIdSpecification), typeof(SpanishIdConverter))]
    public string? PlayerId { get; set; }

    [FilterSpecification(typeof(TeamSpecification))]
    public Guid? TeamId { get; set; }
}

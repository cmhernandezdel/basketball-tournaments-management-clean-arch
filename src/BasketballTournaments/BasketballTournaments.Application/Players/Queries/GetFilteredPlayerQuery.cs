using BasketballTournaments.Application.Players.DTO;
using MediatR;

namespace BasketballTournaments.Application.Players.Queries;

public sealed class GetFilteredPlayerQuery : IRequest<IEnumerable<PlayerDto>>
{
    public PlayersFilter? Filter { get; set; }

    public GetFilteredPlayerQuery()
    {
        // This empty constructor is required to use [FromQuery]
        // If we do not use it [FromQuery], validator will not be fired
        // See: https://github.com/dotnet/aspnetcore/issues/9781
    }

    public GetFilteredPlayerQuery(PlayersFilter? filter)
    {
        Filter = filter;
    }
}

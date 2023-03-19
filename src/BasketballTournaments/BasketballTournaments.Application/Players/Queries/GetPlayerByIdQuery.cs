using BasketballTournaments.Application.Players.DTO;
using FluentResults;
using MediatR;

namespace BasketballTournaments.Application.Players.Queries;

public sealed class GetPlayerByIdQuery : IRequest<Result<PlayerDto>>
{
    public Guid Id { get; }

    public GetPlayerByIdQuery(Guid id)
    {
        Id = id;
    }
}

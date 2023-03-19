using AutoMapper;
using BasketballTournaments.Application.Players.DTO;
using BasketballTournaments.Application.Players.Queries;
using BasketballTournaments.Application.Shared.Errors;
using BasketballTournaments.Domain.Players;
using BasketballTournaments.Infrastructure.Players.Repositories;
using FluentResults;
using MediatR;

namespace BasketballTournaments.Application.Players.Handlers;

public sealed class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdQuery, Result<PlayerDto>>
{
    private readonly IPlayersReadRepository _repository;
    private readonly IMapper _mapper;

    public GetPlayerByIdHandler(IPlayersReadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<PlayerDto>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        Result<Player> queryResult = await _repository.GetById(request.Id, cancellationToken);
        if (queryResult.IsFailed)
        {
            return Result.Fail(new ItemNotFoundError());
        }

        Player player = queryResult.Value;
        PlayerDto dto = _mapper.Map<PlayerDto>(player);
        return dto;
    }
}

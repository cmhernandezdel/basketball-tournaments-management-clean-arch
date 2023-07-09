using AutoMapper;
using BasketballTournaments.Application.Players.Commands;
using BasketballTournaments.Application.Players.DTO;
using BasketballTournaments.Application.Shared.Errors;
using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.Infrastructure.Players.Repositories;
using FluentResults;
using MediatR;

namespace BasketballTournaments.Application.Players.Handlers;

public sealed class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, Result<PlayerDto>>
{
    private readonly IPlayersWriteRepository _repository;
    private readonly IMapper _mapper;

    public CreatePlayerHandler(IPlayersWriteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<PlayerDto>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        Result<Player> creationResult = Player.Create(
            idNumber: SpanishId.FromString(request.IdNumber.Trim()).Value,
            name: request.Name.Trim(),
            surname: request.Surname.Trim(),
            heightInCentimeters: request.HeightInCentimeters,
            weightInKilograms: request.WeightInKilograms,
            position: request.Position,
            teamId: request.TeamId
        );

        if (creationResult.IsFailed)
        {
            return Result.Fail(new InvalidArgumentError());
        }

        Player itemToInsert = creationResult.Value;
        await _repository.Insert(itemToInsert, cancellationToken);
        PlayerDto dto = _mapper.Map<PlayerDto>(itemToInsert);
        return Result.Ok(dto);
    }
}

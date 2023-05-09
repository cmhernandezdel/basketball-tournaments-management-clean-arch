using AutoMapper;
using BasketballTournaments.Application.Players.DTO;
using BasketballTournaments.Application.Players.Queries;
using BasketballTournaments.Application.Shared.Queries;
using BasketballTournaments.Domain.Players;
using BasketballTournaments.Infrastructure.Players.Repositories;
using BasketballTournaments.SeedWork;
using MediatR;

namespace BasketballTournaments.Application.Players.Handlers;

public sealed class GetFilteredPlayerHandler : IRequestHandler<GetFilteredPlayerQuery, IEnumerable<PlayerDto>>
{
    private readonly IPlayersReadRepository _repository;
    private readonly IFilterService _filterService;
    private readonly IMapper _mapper;

    public GetFilteredPlayerHandler(IPlayersReadRepository repository, IFilterService filterService, IMapper mapper)
    {
        _repository = repository;
        _filterService = filterService;
        _mapper = mapper;
    }


    public async Task<IEnumerable<PlayerDto>> Handle(GetFilteredPlayerQuery request, CancellationToken cancellationToken)
    {
        Specification<Player> specification = _filterService.CreateSpecificationFromFilters<Player>(request.Filter);
        IEnumerable<Player> queryResult = await _repository.Get(specification, cancellationToken);
        IEnumerable<PlayerDto> returnResult = queryResult.Select(entity => _mapper.Map<PlayerDto>(entity));
        return returnResult;
    }
}

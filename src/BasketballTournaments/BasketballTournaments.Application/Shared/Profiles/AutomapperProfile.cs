using AutoMapper;
using BasketballTournaments.Application.Players.DTO;
using BasketballTournaments.Domain.Players;

namespace BasketballTournaments.Application.Shared.Profiles;

public sealed class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Player, PlayerDto>();
    }
}

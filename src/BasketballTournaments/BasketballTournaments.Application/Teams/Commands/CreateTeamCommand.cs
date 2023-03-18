using BasketballTournaments.Application.Teams.DTO;
using FluentResults;
using MediatR;

namespace BasketballTournaments.Application.Teams.Commands;

public sealed class CreateTeamCommand : IRequest<Result<TeamDto>>
{
    public string Name { get; }

    public string City { get; }

    public string Email { get; }

    public string PhoneNumber { get; }

    public string CaptainId { get; }

    public CreateTeamCommand(string name, string city, string email, string phoneNumber, string captainId)
    {
        Name = name;
        City = city;
        Email = email;
        PhoneNumber = phoneNumber;
        CaptainId = captainId;
    }
}

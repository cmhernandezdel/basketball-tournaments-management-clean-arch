using MediatR;
using FluentResults;
using BasketballTournaments.Domain.Players;
using BasketballTournaments.Application.Players.DTO;

namespace BasketballTournaments.Application.Players.Commands;

public sealed class CreatePlayerCommand : IRequest<Result<PlayerDto>>
{
    public string IdNumber { get; }

    public string Name { get; }

    public string Surname { get; }

    public int HeightCentimeters { get; }

    public double WeightKilograms { get; }

    public Position Position { get; }

    public Guid TeamId { get; }

    public CreatePlayerCommand(string idNumber, string name, string surname, int heightCentimeters, double weightKilograms, Position position, Guid teamId)
    {
        IdNumber = idNumber;
        Name = name;
        Surname = surname;
        HeightCentimeters = heightCentimeters;
        WeightKilograms = weightKilograms;
        Position = position;
        TeamId = teamId;
    }
}

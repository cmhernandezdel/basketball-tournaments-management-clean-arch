using BasketballTournaments.Domain.Players;

namespace BasketballTournaments.Application.Players.DTO;

public sealed class PlayerDto
{
    public Guid Id { get; }

    public string IdNumber { get; }

    public string Name { get; }

    public string Surname { get; }

    public int HeightCentimeters { get; }

    public double WeightKilograms { get; }

    public Position Position { get; }

    public Guid TeamId { get; }

    public PlayerDto(Guid id, string idNumber, string name, string surname, int heightCentimeters, double weightKilograms, Position position, Guid teamId)
    {
        Id = id;
        IdNumber = idNumber;
        Name = name;
        Surname = surname;
        HeightCentimeters = heightCentimeters;
        WeightKilograms = weightKilograms;
        Position = position;
        TeamId = teamId;
    }
}

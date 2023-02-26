using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.Players;

public sealed class Player: Entity
{
    public SpanishId IdNumber { get; }

    public string Name { get; }

    public string Surname { get; }

    public int HeightCentimeters { get; private set; }

    public double WeightKilograms { get; private set; }

    public Position Position { get; }

    public Guid TeamId { get; }

    public Player(SpanishId idNumber, string name, string surname, int heightCentimeters, double weightKilograms, Position position, Guid teamId) : base()
    {
        IdNumber = idNumber;
        Name = name;
        Surname = surname;
        HeightCentimeters = heightCentimeters;
        WeightKilograms = weightKilograms;
        Position = position;
        TeamId = teamId;
    }

    public void SetHeight(int heightInCentimeters)
    {
        HeightCentimeters = heightInCentimeters;
    }

    public void SetWeight(double weightInKilograms)
    {
        WeightKilograms = weightInKilograms;
    }
}
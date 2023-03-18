using System.Globalization;
using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.Players;

public sealed partial class Player : Entity
{
    public SpanishId IdNumber { get; }

    public string Name { get; }

    public string Surname { get; }

    public int HeightCentimeters { get; private set; }

    public double WeightKilograms { get; private set; }

    public Position Position { get; }

    public Guid TeamId { get; }

    public static Result<Player> Create(SpanishId idNumber, string name, string surname, int heightInCentimeters, double weightInKilograms, Position position, Guid teamId)
    {
        string trimmedName = name.Trim();
        string trimmedSurname = surname.Trim();

        Result validationResult = Result.Merge(
            Result.FailIf(string.IsNullOrEmpty(trimmedName), "Name cannot be empty."),
            Result.FailIf(trimmedName.Length > MaxLengthName, $"Name cannot exceed {MaxLengthName} characters."),
            Result.FailIf(string.IsNullOrEmpty(trimmedSurname), "Surname cannot be empty."),
            Result.FailIf(trimmedSurname.Length > MaxLengthSurname, $"Name cannot exceed {MaxLengthSurname} characters.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new Player(idNumber, name, surname, heightInCentimeters, weightInKilograms, position, teamId));
    }

    private Player(SpanishId idNumber, string name, string surname, int heightCentimeters, double weightKilograms, Position position, Guid teamId) : base()
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
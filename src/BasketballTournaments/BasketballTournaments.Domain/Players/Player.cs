using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.Domain.Teams;
using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.Players;

public sealed partial class Player : Entity
{
    public SpanishId IdNumber { get; }

    public string Name { get; }

    public string Surname { get; }

    public uint HeightInCentimeters { get; private set; }

    public double WeightInKilograms { get; private set; }

    public Position Position { get; }

    public Guid TeamId { get; }

    public static Result<Player> Create(
        SpanishId idNumber,
        string name,
        string surname,
        uint heightInCentimeters,
        double weightInKilograms,
        Position position,
        Team team)
    {
        string trimmedName = name.Trim();
        string trimmedSurname = surname.Trim();

        Result validationResult = Result.Merge(
            Result.FailIf(string.IsNullOrEmpty(trimmedName), "Name cannot be empty."),
            Result.FailIf(trimmedName.Length > MaxLengthName, $"Name cannot exceed {MaxLengthName} characters."),
            Result.FailIf(string.IsNullOrEmpty(trimmedSurname), "Surname cannot be empty."),
            Result.FailIf(trimmedSurname.Length > MaxLengthSurname, $"Name cannot exceed {MaxLengthSurname} characters."),
            Result.FailIf(weightInKilograms <= 0, "Weight cannot be a negative number.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new Player(idNumber, name, surname, heightInCentimeters, weightInKilograms, position, team.Id));
    }

    private Player(SpanishId idNumber, string name, string surname, uint heightCentimeters, double weightKilograms, Position position, Guid teamId) : base()
    {
        IdNumber = idNumber;
        Name = name;
        Surname = surname;
        HeightInCentimeters = heightCentimeters;
        WeightInKilograms = weightKilograms;
        Position = position;
        TeamId = teamId;
    }

    public void SetHeight(uint heightInCentimeters)
    {
        HeightInCentimeters = heightInCentimeters;
    }

    public Result SetWeight(double weightInKilograms)
    {
        Result validationResult = Result.FailIf(weightInKilograms <= 0, "Weight cannot be a negative number.");
        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        WeightInKilograms = weightInKilograms;
        return Result.Ok();
    }
}
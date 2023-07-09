using BasketballTournaments.Application.Players.Commands;
using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Shared.ValueObjects;
using FluentResults;
using FluentValidation;

namespace BasketballTournaments.Application.Players.Validators;

public sealed class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
{
    public CreatePlayerCommandValidator()
    {
        RuleFor(command => command.IdNumber)
            .NotEmpty()
            .Must(idNumber =>
            {
                Result<SpanishId> conversionResult = SpanishId.FromString(idNumber);
                return conversionResult.IsSuccess;
            });

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(Player.MaxLengthName);

        RuleFor(command => command.Surname)
            .NotEmpty()
            .MaximumLength(Player.MaxLengthSurname);

        RuleFor(command => command.HeightInCentimeters)
            .NotNull()
            .GreaterThan(0);

        RuleFor(command => command.WeightInKilograms)
            .NotNull()
            .GreaterThan(0.0);

        RuleFor(command => command.Position)
            .NotNull()
            .IsInEnum();

        RuleFor(command => command.TeamId)
            .NotEmpty();
    }
}

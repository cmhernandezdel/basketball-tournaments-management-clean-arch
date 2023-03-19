using BasketballTournaments.Application.Players.Queries;
using FluentValidation;

namespace BasketballTournaments.Application.Players.Validators;

public sealed class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
{
    public GetPlayerByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty();
    }
}

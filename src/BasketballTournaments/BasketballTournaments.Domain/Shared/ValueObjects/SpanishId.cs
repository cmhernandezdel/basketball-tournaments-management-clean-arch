using FluentResults;
using System.Text.RegularExpressions;

namespace BasketballTournaments.Domain.Shared.ValueObjects;

public sealed class SpanishId
{
    public string Number { get; }

    private SpanishId(string number)
    {
        Number = number;
    }

    public static Result<SpanishId> FromString(string number)
    {
        string pattern = @"[0-9]{8}[a-zA-Z]";
        bool isValid = Regex.IsMatch(number, pattern);
        if (!isValid) return Result.Fail("Validation failed.");
        return Result.Ok(new SpanishId(number));
    }
}
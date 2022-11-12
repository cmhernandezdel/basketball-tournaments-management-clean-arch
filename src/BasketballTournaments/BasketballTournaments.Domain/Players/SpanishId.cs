using LanguageExt;
using System.Text.RegularExpressions;

namespace BasketballTournaments.Domain.Players;

public sealed class SpanishId
{
    public string Number { get; }

    private SpanishId(string number)
    {
        Number = number;
    }

    public static Option<SpanishId> FromString(string number)
    {
        string pattern = @"[0-9]{8}[a-zA-Z]";
        bool isValid = Regex.IsMatch(number, pattern);
        if (!isValid) return Option<SpanishId>.None;
        return new SpanishId(number);
    }
}
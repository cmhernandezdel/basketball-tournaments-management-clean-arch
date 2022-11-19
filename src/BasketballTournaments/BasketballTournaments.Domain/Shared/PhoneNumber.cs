using LanguageExt;
using System.Text.RegularExpressions;

namespace BasketballTournaments.Domain.Shared;

public sealed class PhoneNumber
{
    // See: https://uibakery.io/regex-library/phone-number-csharp
    private const string ValidationRegex = "^\\+?[1-9][0-9]{7,14}$";

    private string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static Option<PhoneNumber> FromString(string number)
    {
        bool isValid = Regex.IsMatch(number, ValidationRegex);
        if (!isValid) 
        {
            return Option<PhoneNumber>.None;
        }

        return new PhoneNumber(number);
    }

    public static implicit operator string(PhoneNumber number) => number.Number;
}

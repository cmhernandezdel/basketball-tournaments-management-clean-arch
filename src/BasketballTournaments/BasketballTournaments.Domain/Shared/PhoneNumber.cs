using FluentResults;
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

    public static Result<PhoneNumber> FromString(string number)
    {
        bool isValid = Regex.IsMatch(number, ValidationRegex);
        if (!isValid)
        {
            return Result.Fail("Validation failed.");
        }

        return Result.Ok(new PhoneNumber(number));
    }

    public static implicit operator string(PhoneNumber number) => number.Number;
}

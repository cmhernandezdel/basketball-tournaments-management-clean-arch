using System.Text.RegularExpressions;
using FluentResults;

namespace BasketballTournaments.Domain.Shared.ValueObjects;

public sealed class PhoneNumber : ValueObject
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

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Number;
    }

    public static implicit operator string(PhoneNumber number) => number.Number;


}

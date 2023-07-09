using System.Text.RegularExpressions;
using FluentResults;

namespace BasketballTournaments.Domain.Shared;

public sealed class Email : ValueObject
{
    // See: https://stackoverflow.com/a/13704625/8966471
    private const string ValidationRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

    private string Address { get; }

    private Email(string address)
    {
        Address = address;
    }

    public static Result<Email> FromString(string address)
    {
        bool isValid = Regex.IsMatch(address, ValidationRegex);
        if (!isValid)
        {
            return Result.Fail("Validation failed.");
        }

        return Result.Ok(new Email(address));
    }

    public static implicit operator string(Email email) => email.Address;

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Address;
    }
}

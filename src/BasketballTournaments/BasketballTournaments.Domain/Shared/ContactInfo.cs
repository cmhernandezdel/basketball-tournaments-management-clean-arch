namespace BasketballTournaments.Domain.Shared;

public sealed class ContactInfo : ValueObject
{
    public Email Email { get; }

    public PhoneNumber PhoneNumber { get; }

    public ContactInfo(Email email, PhoneNumber phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Email;
        yield return PhoneNumber;
    }
}

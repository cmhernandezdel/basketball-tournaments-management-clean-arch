namespace BasketballTournaments.Domain.Shared;

public sealed class ContactInfo
{
    public Email Email { get; }

    public PhoneNumber PhoneNumber { get; }

    public ContactInfo(Email email, PhoneNumber phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }
}

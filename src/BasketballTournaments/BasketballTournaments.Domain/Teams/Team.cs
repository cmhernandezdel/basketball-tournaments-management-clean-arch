using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.Teams;

public sealed class Team : Entity
{
    public string Name { get; }

    public string City { get; }

    public ContactInfo ContactInfo { get; private set; }

    public SpanishId CaptainId { get; private set; }

    public Team(string name, string city, ContactInfo contactInfo, SpanishId captainId) : base()
    {
        Name = name;
        City = city;
        ContactInfo = contactInfo;
        CaptainId = captainId;
    }

    public void SetContactInfo(ContactInfo contactInfo)
    {
        ContactInfo = contactInfo;
    }

    public void SetCaptain(Player captain)
    {
        if (captain.TeamId != Id)
        {
            throw new ArgumentException("Player must be assigned to this team to be its captain!");
        }

        CaptainId = captain.IdNumber;
    }
}

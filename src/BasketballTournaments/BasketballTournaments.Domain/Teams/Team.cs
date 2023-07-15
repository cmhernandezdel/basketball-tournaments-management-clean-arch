using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.Teams;

public sealed partial class Team : Entity
{
    private readonly List<Player> _players;

    public string Name { get; }

    public string City { get; }

    public ContactInfo ContactInfo { get; private set; }

    public Guid CaptainId { get; private set; }

    public IEnumerable<Player> Players { get => _players.AsEnumerable(); }

    public static Result<Team> Create(string name, string city, ContactInfo contactInfo, IEnumerable<Player> players, Player captain)
    {
        string trimmedName = name.Trim();
        string trimmedCity = city.Trim();

        Result validationResult = Result.Merge(
            Result.FailIf(string.IsNullOrEmpty(trimmedName), $"Name cannot be empty"),
            Result.FailIf(name.Length > MaxLengthName, $"Name cannot be longer than ${MaxLengthName} characters."),
            Result.FailIf(string.IsNullOrEmpty(trimmedCity), $"City cannot be empty"),
            Result.FailIf(city.Length > MaxLengthCity, $"City cannot be longer than ${MaxLengthCity} characters."),
            Result.FailIf(!players.Contains(captain), "Captain does not belong to this team.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new Team(trimmedName, trimmedCity, contactInfo, players, captain.Id));
    }

    public Team(string name, string city, ContactInfo contactInfo, IEnumerable<Player> players, Guid captainId) : base()
    {
        _players = players.ToList();
        Name = name;
        City = city;
        ContactInfo = contactInfo;
        CaptainId = captainId;
    }

    public void SetContactInfo(ContactInfo contactInfo)
    {
        ContactInfo = contactInfo;
    }

    public Result AddPlayer(Player player)
    {
        
    }

    public void SetCaptain(Player captain)
    {
        if (captain.TeamId != Id)
        {
            throw new ArgumentException("Player must be assigned to this team to be its captain!");
        }

        CaptainId = captain.Id;
    }
}

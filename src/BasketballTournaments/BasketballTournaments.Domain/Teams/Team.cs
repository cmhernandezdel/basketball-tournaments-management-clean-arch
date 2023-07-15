using System.ComponentModel.DataAnnotations;
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
        Result validationResult = Result.FailIf(player.TeamId is not null, "Player is already assigned to another team.");
        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        _players.Add(player);
        player.SetTeam(this);
        return Result.Ok();
    }

    public Result RemovePlayer(Player player)
    {
        Result validationResult = Result.Merge(
            Result.FailIf(!_players.Contains(player), "Player is not assigned to this team."),
            Result.FailIf(CaptainId == player.Id, "Cannot remove captain from team until another captain is set.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        _players.Remove(player);
        player.SetTeam(null);
        return Result.Ok();
    }

    public Result SetCaptain(Player captain)
    {
        Result validationResult = Result.FailIf(!_players.Contains(captain), "Player is not assigned to this team.");
        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        CaptainId = captain.Id;
        return Result.Ok();
    }
}

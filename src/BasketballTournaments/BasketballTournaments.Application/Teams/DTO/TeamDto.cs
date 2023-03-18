namespace BasketballTournaments.Application.Teams.DTO;

public sealed class TeamDto
{
    public Guid Id { get; }

    public string Name { get; }

    public string City { get; }

    public string Email { get; }

    public string PhoneNumber { get; }

    public string CaptainId { get; }

    public TeamDto(Guid id, string name, string city, string email, string phoneNumber, string captainId)
    {
        Id = id;
        Name = name;
        City = city;
        Email = email;
        PhoneNumber = phoneNumber;
        CaptainId = captainId;
    }
}

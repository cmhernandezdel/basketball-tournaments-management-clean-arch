using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.Tournaments;

public sealed class Tournament : Entity
{
    public DateTime StartTimestampUtc { get; }

    public DateTime EndTimestampUtc { get; }

    public string Venue { get; }

    public Tournament(DateTime startTimestampUtc, DateTime endTimestampUtc, string venue)
    {
        StartTimestampUtc = startTimestampUtc;
        EndTimestampUtc = endTimestampUtc;
        Venue = venue;
    }

}

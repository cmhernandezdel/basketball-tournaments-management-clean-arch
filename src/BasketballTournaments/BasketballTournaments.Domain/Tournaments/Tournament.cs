using BasketballTournaments.SeedWork;
using FluentResults;

namespace BasketballTournaments.Domain.Tournaments;

public sealed partial class Tournament : Entity
{
    public DateTime StartTimestampUtc { get; }

    public DateTime EndTimestampUtc { get; }

    public string Venue { get; }

    public Result<Tournament> Create(DateTime startTimestampUtc, DateTime endTimestampUtc, string venue)
    {
        string trimmedVenue = venue.Trim();

        Result validationResult = Result.Merge(
            Result.FailIf(startTimestampUtc >= endTimestampUtc, "Start date and time cannot be after end date and time."),
            Result.FailIf(string.IsNullOrEmpty(trimmedVenue), "Venue cannot be empty."),
            Result.FailIf(trimmedVenue.Length > MaxLengthVenue, $"Venue cannot exceed {MaxLengthVenue} characters.")
        );

        if (validationResult.IsFailed)
        {
            return validationResult;
        }

        return Result.Ok(new Tournament(startTimestampUtc, endTimestampUtc, trimmedVenue));
    }

    private Tournament(DateTime startTimestampUtc, DateTime endTimestampUtc, string venue)
    {
        StartTimestampUtc = startTimestampUtc;
        EndTimestampUtc = endTimestampUtc;
        Venue = venue;
    }
}

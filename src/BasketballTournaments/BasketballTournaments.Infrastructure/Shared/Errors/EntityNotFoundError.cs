using FluentResults;

namespace BasketballTournaments.Infrastructure.Shared.Errors;

public sealed class EntityNotFoundError : IError
{
    public List<IError> Reasons => new();

    public string Message => "Entity was not found in the database.";

    public Dictionary<string, object> Metadata => new();
}
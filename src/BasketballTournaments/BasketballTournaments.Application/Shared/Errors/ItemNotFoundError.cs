using FluentResults;

namespace BasketballTournaments.Application.Shared.Errors;

public sealed class ItemNotFoundError : IError
{
    public List<IError> Reasons => new List<IError>();

    public string Message => "Item was not found.";

    public Dictionary<string, object> Metadata => new Dictionary<string, object>();
}

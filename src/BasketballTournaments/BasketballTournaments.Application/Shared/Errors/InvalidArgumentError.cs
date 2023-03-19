using FluentResults;

namespace BasketballTournaments.Application.Shared.Errors;

public sealed class InvalidArgumentError : IError
{
    public List<IError> Reasons => new List<IError>();

    public string Message => "One or more arguments provided were not valid.";

    public Dictionary<string, object> Metadata => new Dictionary<string, object>();
}

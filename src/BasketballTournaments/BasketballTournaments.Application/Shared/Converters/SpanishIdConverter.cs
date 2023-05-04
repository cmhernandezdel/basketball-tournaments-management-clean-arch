using BasketballTournaments.Application.Shared.Queries;
using BasketballTournaments.Domain.Players;
using FluentResults;

namespace BasketballTournaments.Application.Shared.Converters;

public sealed class SpanishIdConverter : ITypeConverter
{
    public bool CanConvertFrom(Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }
        return false;
    }

    public object? ConvertFrom(object value)
    {
        if (value is string valueAsString)
        {
            Result<SpanishId> convertedValue = SpanishId.FromString(valueAsString);
            SpanishId? returnValue = convertedValue.ValueOrDefault;
            return returnValue;
        }
        return null;
    }
}

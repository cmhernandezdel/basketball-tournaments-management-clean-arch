using BasketballTournaments.Domain.Players;
using LanguageExt.UnsafeValueAccess;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketballTournaments.Infrastructure.Shared.ValueConverters;

public sealed class SpanishIdValueConverter : ValueConverter<SpanishId, string>
{
    public SpanishIdValueConverter() : base(
        convertToProviderExpression: entity => entity.Number,
        convertFromProviderExpression: databaseValue => SpanishId.FromString(databaseValue).ValueUnsafe())
    {
    }
}
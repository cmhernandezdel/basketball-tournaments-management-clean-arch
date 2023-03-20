namespace BasketballTournaments.Application.Shared.Queries;

public interface ITypeConverter
{
    bool CanConvertFrom(Type sourceType);
    object? ConvertFrom(object value);
}

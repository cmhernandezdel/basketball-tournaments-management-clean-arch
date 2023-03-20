namespace BasketballTournaments.Application.Shared.Queries;

[AttributeUsage(AttributeTargets.Property)]
public sealed class FilterSpecificationAttribute : Attribute
{
    public Type Specification { get; }
    public Type? ConversionType { get; private set; }

    public FilterSpecificationAttribute(Type specification)
    {
        Specification = specification;
    }

    public FilterSpecificationAttribute(Type specification, Type conversionType)
    {
        Specification = specification;
        ConversionType = conversionType;
    }
}

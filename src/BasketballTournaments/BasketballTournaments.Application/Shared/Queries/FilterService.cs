using System.Reflection;
using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Application.Shared.Queries;

public class FilterService : IFilterService
{
    public Specification<T> CreateSpecificationFromFilters<T>(IQueryStringFilter? filters)
    {
        if (filters is null)
        {
            return new EmptySpecification<T>();
        }

        PropertyInfo[] properties = filters.GetType().GetProperties() ?? Array.Empty<PropertyInfo>();
        Specification<T>? specifications = null;

        foreach (PropertyInfo property in properties)
        {
            FilterSpecificationAttribute? attribute = (FilterSpecificationAttribute?)Attribute.GetCustomAttribute(property, typeof(FilterSpecificationAttribute));
            if (attribute is null)
            {
                continue;
            }

            var value = property.GetValue(filters);
            if (value is null)
            {
                continue;
            }

            var valueConverted = ApplyConversion(property.GetValue(filters), attribute.ConversionType);
            var specification = (Specification<T>?)Activator.CreateInstance(attribute.Specification, valueConverted);
            if (specification is not null)
            {
                specifications = specifications is null ? specification : specifications.And(specification);
            }
        }

        return specifications ?? new EmptySpecification<T>();
    }

    private static object? ApplyConversion(object? value, Type? conversionTypeConverter)
    {
        if (conversionTypeConverter is null || value is null)
        {
            return value;
        }

        if (conversionTypeConverter.IsAssignableTo(typeof(ITypeConverter)))
        {
            var converter = (ITypeConverter?)Activator.CreateInstance(conversionTypeConverter!);

            return converter is not null && converter!.CanConvertFrom(value.GetType()) ? converter.ConvertFrom(value) : value;
        }

        return value;
    }
}

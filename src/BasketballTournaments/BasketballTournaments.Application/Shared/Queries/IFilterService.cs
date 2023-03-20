using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Application.Shared.Queries;

public interface IFilterService
{
    Specification<T> CreateSpecificationFromFilters<T>(IQueryStringFilter? filters);
}

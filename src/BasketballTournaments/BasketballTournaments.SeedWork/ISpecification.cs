using System.Linq.Expressions;

namespace BasketballTournaments.SeedWork;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();

    bool IsSatisfiedBy(T entity);
}

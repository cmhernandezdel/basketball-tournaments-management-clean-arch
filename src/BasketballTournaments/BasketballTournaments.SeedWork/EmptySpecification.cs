using System.Linq.Expressions;

namespace BasketballTournaments.SeedWork;

public sealed class EmptySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return (T) => true;
    }
}

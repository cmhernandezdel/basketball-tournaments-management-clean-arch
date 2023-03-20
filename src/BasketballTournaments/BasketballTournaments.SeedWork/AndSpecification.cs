using System.Linq.Expressions;

namespace BasketballTournaments.SeedWork;

public class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = _left.ToExpression();
        Expression<Func<T, bool>> rightExpression = _right.ToExpression();

        var visitor = new SwapVisitor(leftExpression.Parameters[0], rightExpression.Parameters[0]);
        var binaryExpression = Expression.AndAlso(visitor.Visit(leftExpression.Body), rightExpression.Body);
        var lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, rightExpression.Parameters);
        return lambda;
    }
}

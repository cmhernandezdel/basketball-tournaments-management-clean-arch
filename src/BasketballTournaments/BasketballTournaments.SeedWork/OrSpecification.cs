using System.Linq.Expressions;

namespace BasketballTournaments.SeedWork;

public class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = _left.ToExpression();
        Expression<Func<T, bool>> rightExpression = _right.ToExpression();

        SwapVisitor visitor = new(leftExpression.Parameters[0], rightExpression.Parameters[0]);
        BinaryExpression? binaryExpression = Expression.OrElse(visitor.Visit(leftExpression.Body), rightExpression.Body);
        Expression<Func<T, bool>>? lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, rightExpression.Parameters);
        return lambda;
    }
}


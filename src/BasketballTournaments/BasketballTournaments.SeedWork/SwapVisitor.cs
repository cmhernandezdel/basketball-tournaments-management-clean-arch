using System.Linq.Expressions;

namespace BasketballTournaments.SeedWork;

public class SwapVisitor : ExpressionVisitor
{
    private readonly Expression from, to;

    public SwapVisitor(Expression from, Expression to)
    {
        this.from = from;
        this.to = to;
    }

    public override Expression Visit(Expression? node)
    {
        if (node is null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        return node == from ? to : base.Visit(node);
    }
}


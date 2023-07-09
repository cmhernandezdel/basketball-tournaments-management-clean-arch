using System.Linq.Expressions;
using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.SeedWork;

namespace BasketballTournaments.Domain.Players;

public sealed partial class Player
{
    public static SpanishIdSpecification BySpanishId(SpanishId playerId)
    {
        return new SpanishIdSpecification(playerId);
    }

    public static TeamSpecification ByTeam(Guid teamId)
    {
        return new TeamSpecification(teamId);
    }

    public class SpanishIdSpecification : Specification<Player>
    {
        private readonly SpanishId _playerId;

        internal SpanishIdSpecification(SpanishId playerId)
        {
            _playerId = playerId;
        }

        public override Expression<Func<Player, bool>> ToExpression()
        {
            return player => player.IdNumber.Equals(_playerId);
        }
    }

    public class TeamSpecification : Specification<Player>
    {
        private readonly Guid _teamId;

        internal TeamSpecification(Guid teamId)
        {
            _teamId = teamId;
        }

        public override Expression<Func<Player, bool>> ToExpression()
        {
            return player => player.TeamId == _teamId;
        }
    }
}

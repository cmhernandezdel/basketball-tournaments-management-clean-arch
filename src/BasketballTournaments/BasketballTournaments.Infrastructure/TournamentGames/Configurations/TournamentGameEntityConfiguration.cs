using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.TournamentGames;
using BasketballTournaments.Domain.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballTournaments.Infrastructure.TournamentGames.Configurations;

public sealed class TournamentGameEntityConfiguration : IEntityTypeConfiguration<TournamentGame>
{
    public void Configure(EntityTypeBuilder<TournamentGame> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.HomeTeamId)
            .IsRequired();
        builder.Property(entity => entity.AwayTeamId)
            .IsRequired();
        builder.Property(entity => entity.HomeTeamPoints)
            .IsRequired();
        builder.Property(entity => entity.AwayTeamPoints)
            .IsRequired();
        builder.Property(entity => entity.Stage)
            .IsRequired();
        builder.Property(entity => entity.MostValuablePlayerId)
            .IsRequired();
        builder.Property(entity => entity.TimestampUtc)
            .IsRequired();

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(entity => entity.MostValuablePlayerId);

        builder.HasOne<Tournament>()
            .WithMany()
            .HasForeignKey(entity => entity.TournamentId);
    }
}

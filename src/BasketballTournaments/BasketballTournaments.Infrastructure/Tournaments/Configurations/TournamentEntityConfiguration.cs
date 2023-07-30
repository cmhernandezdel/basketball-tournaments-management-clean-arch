using BasketballTournaments.Domain.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballTournaments.Infrastructure.Tournaments.Configurations;

public sealed class TournamentEntityConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.StartTimestampUtc)
            .IsRequired();
        builder.Property(entity => entity.EndTimestampUtc)
            .IsRequired();
        builder.Property(entity => entity.Venue)
            .IsRequired()
            .HasMaxLength(Tournament.MaxLengthVenue);
    }
}

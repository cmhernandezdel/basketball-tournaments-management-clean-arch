using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballTournaments.Infrastructure.Teams.Configurations;

public sealed class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(Team.MaxLengthName);
        builder.Property(entity => entity.City)
            .IsRequired()
            .HasMaxLength(Team.MaxLengthCity);
        builder.Property(entity => entity.ContactInfo)
            .IsRequired();
        builder.Property(entity => entity.CaptainId)
            .IsRequired();
    }
}

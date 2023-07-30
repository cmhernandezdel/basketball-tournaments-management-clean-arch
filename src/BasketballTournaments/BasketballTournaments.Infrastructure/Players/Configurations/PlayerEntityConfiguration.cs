using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballTournaments.Infrastructure.Players.Configurations;

public sealed class PlayerEntityConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasAlternateKey(entity => entity.IdNumber);
        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(Player.MaxLengthName);
        builder.Property(entity => entity.Surname)
            .IsRequired()
            .HasMaxLength(Player.MaxLengthSurname);
        builder.Property(entity => entity.Position)
            .IsRequired();
        builder.Property(entity => entity.HeightInCentimeters)
            .IsRequired();
        builder.Property(entity => entity.WeightInKilograms)
            .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(entity => entity.TeamId);
    }
}

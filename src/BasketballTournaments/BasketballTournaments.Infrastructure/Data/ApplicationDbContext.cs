using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Shared.ValueObjects;
using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Domain.TournamentGames;
using BasketballTournaments.Domain.Tournaments;
using BasketballTournaments.Infrastructure.Players.Configurations;
using BasketballTournaments.Infrastructure.Shared.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Player> Players => Set<Player>();

    public DbSet<Team> Teams => Set<Team>();

    public DbSet<Tournament> Tournaments => Set<Tournament>();

    public DbSet<TournamentGame> TournamentGames => Set<TournamentGame>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations here
        modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<SpanishId>().HaveConversion<SpanishIdValueConverter>();
    }

}
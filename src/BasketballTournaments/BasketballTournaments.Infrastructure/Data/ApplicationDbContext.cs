using BasketballTournaments.Domain.Players;
using BasketballTournaments.Domain.Teams;
using BasketballTournaments.Infrastructure.Players.Configurations;
using BasketballTournaments.Infrastructure.Shared.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BasketballTournaments.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Player> Players => Set<Player>();

    public DbSet<Team> Teams => Set<Team>();

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
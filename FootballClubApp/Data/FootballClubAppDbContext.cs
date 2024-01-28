namespace FootballClubApp.Data;

using Microsoft.EntityFrameworkCore;
using FootballClubApp.Data.Entities;
using Microsoft.Extensions.Configuration;

public class FootballClubAppDbContext : DbContext
{
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Opponent> Opponents => Set<Opponent>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfiguration configuration = configurationBuilder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        modelBuilder.Entity<Player>()
            .Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(30);

        modelBuilder.Entity<Player>()
            .Property(p => p.Position)
            .IsRequired();

        modelBuilder.Entity<Player>()
            .Property(p => p.Nationality)
            .IsRequired();

        modelBuilder.Entity<Player>()
            .Property(p => p.WeeklyWage)
            .HasColumnType("decimal(18,4)");

        modelBuilder.Entity<Player>()
            .Property(p => p.MarketValue)
            .HasColumnType("decimal(18,4)");

        modelBuilder.Entity<Opponent>()
            .Property(p => p.TeamName)
            .IsRequired()
            .HasMaxLength(50);
    }
}

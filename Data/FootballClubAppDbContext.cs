namespace FootballClubApp.Data;

using Microsoft.EntityFrameworkCore;

public class FootballClubAppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=LAPTOP-KJAE0SCE\SQLEXPRESS;Database=FootballAppDb;Trusted_Connection=True";
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Opponent> Opponents => Set<Opponent>();

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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    //modelBuilder.Entity<Player>()
    //    .HasData(
    //        new Player { Id = 1, FirstName = "Ansu", LastName = "Fati", Number = "10", Position = Position.Attacker },
    //        new Player { Id = 2, FirstName = "Gerard", LastName = "Piqué", Number = "3", Position = Position.Defender },
    //        new Player { Id = 3, FirstName = "Marc-André", LastName = "ter Stegen", Number = "1", Position = Position.Goalkeeper },
    //        new Player { Id = 4, FirstName = "Pablo", LastName = "Gavi", Number = "30", Position = Position.Midfielder },
    //        new Player { Id = 5, FirstName = "Sergio", LastName = "Busquets", Number = "5", Position = Position.Midfielder, IsCaptain = true },
    //        new Player { Id = 6, FirstName = "Nico", LastName = "Gonzalez", Number = "14", Position = Position.Midfielder }
    //    );

    //    modelBuilder.Entity<Opponent>()
    //        .HasData(
    //            new Opponent { Id = 1, TeamName = "Real Madrid", Competition = Competition.LaLiga },
    //            new Opponent { Id = 2, TeamName = "Atletico Madrid", Competition = Competition.LaLiga },
    //            new Opponent { Id = 3, TeamName = "SSC Napoli", Competition = Competition.EuropaLeague },
    //            new Opponent { Id = 4, TeamName = "Athletic Bilbao", Competition = Competition.LaLiga }
    //        );
}

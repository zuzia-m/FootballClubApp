namespace FootballClubApp.Data;

using FootballClubApp.Entities;
using Microsoft.EntityFrameworkCore;

public class FootballClubAppDbContext : DbContext
{
    private string _connectionString = @"Server=LAPTOP-KJAE0SCE\SQLEXPRESS;Database=FootballAppDb;Trusted_Connection=True";
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

        modelBuilder.Entity<Opponent>()
            .Property(p => p.TeamName)
            .IsRequired()
            .HasMaxLength(50);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}


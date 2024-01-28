namespace FootballClubApp.Services;

public class DataGeneratorSql : DataGenerator
{
    private readonly FootballClubAppDbContext _dbContext;

    public DataGeneratorSql(FootballClubAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void ViewDataSourceInfo()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Data provider: SQL Database.\n");
        Console.ResetColor();
    }

    public override void AddPlayers()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Players.Any())
        {
            var players = GetPlayers();
            _dbContext.Players.AddRange(players);
            _dbContext.SaveChanges();
        }
    }

    public override void AddOpponents()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Opponents.Any())
        {
            var opponents = GetOpponents();
            _dbContext.Opponents.AddRange(opponents);
            _dbContext.SaveChanges();
        }
    }
}
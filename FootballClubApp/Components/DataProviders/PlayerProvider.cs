using FootballClubApp.Components.DataProviders.Extensions;

namespace FootballClubApp.Components.DataProviders;

public class PlayerProvider : IPlayerProvider
{
    private readonly IRepository<Player> _playerRepository;

    public PlayerProvider(IRepository<Player> playerRepository)
    {
        _playerRepository = playerRepository;
    }

    // SELECT
    public List<string> GetUniqueNationality()
    {
        var players = _playerRepository.GetAll();
        return players.Select(x => x.Nationality).Distinct().ToList()!;
    }

    public decimal GetMaximumMarketValue()
    {
        var players = _playerRepository.GetAll();
        return players.Select(x => x.MarketValue).Max();
    }

    public decimal GetMinimumWeeklyWage()
    {
        var players = _playerRepository.GetAll();
        return players.Select(x => x.WeeklyWage).Min();
    }

    public List<Player> GetSpecificColumns()
    {
        var players = _playerRepository.GetAll();
        var list = players.Select(x => new Player
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Number = x.Number,
            Position = x.Position
        }).ToList();

        return list;
    }

    public string AnonymousClass()
    {
        var players = _playerRepository.GetAll();
        var list = players.Select(x => new
        {
            Name = x.FirstName + " " + x.LastName,
            Number = x.Number,
            Position = x.Position
        }).ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var player in list)
        {
            sb.AppendLine($"{player.Name}");
            sb.AppendLine($"{player.Number}");
            sb.AppendLine($"{player.Position}");
            sb.AppendLine();
        }

        return sb.ToString();
    }

    // ORDER BY
    public List<Player> OrderByLastNameAndFirstName()
    {
        var players = _playerRepository.GetAll();
        return players.OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName).ToList();
    }

    public List<Player> OrderByLastNameAndFirstNameDescending()
    {
        var players = _playerRepository.GetAll();
        return players.OrderByDescending(x => x.LastName)
            .ThenByDescending(x => x.FirstName).ToList();
    }

    public List<Player> OrderByAgeAndNationality()
    {
        var players = _playerRepository.GetAll();
        return players.OrderByDescending(x => (x.DateOfBirth.Year))
            .ThenBy(x => x.Nationality).ToList();
    }

    public List<Player> OrderByWeeklyWage()
    {
        var players = _playerRepository.GetAll();
        return players.OrderByDescending(x => x.WeeklyWage).ToList();
    }

    public List<Player> OrderByContractTo()
    {
        var players = _playerRepository.GetAll();
        return players.OrderBy(x => x.ContractTo).ToList();
    }

    // WHERE
    public List<Player> PlayersMinMarketValue(decimal minMarketValue)
    {
        var players = _playerRepository.GetAll();
        return players.OrderBy(x => x.MarketValue)
            .Where(x => x.MarketValue >= minMarketValue).ToList();
    }

    public List<Player> PlayersMinWeeklyWage(decimal minWeeklyWage)
    {
        var players = _playerRepository.GetAll();
        return players.OrderBy(x => x.WeeklyWage)
            .Where(x => x.WeeklyWage >= minWeeklyWage).ToList();
    }

    public List<Player> WhereStartsWith(string prefix)
    {
        var players = _playerRepository.GetAll();
        return players.Where(x => x.LastName!.StartsWith(prefix)).ToList();
    }

    public List<Player> WhereStartsWithAndSalaryIsGreaterThan(string prefix, decimal salary)
    {
        var players = _playerRepository.GetAll();
        return players.Where(x => x.LastName!.StartsWith(prefix) && x.WeeklyWage > salary).ToList();
    }

    public List<Player> WhereNationalityIs(string nationality)
    {
        var players = _playerRepository.GetAll();
        return players.ByNationality(nationality).ToList();
        //return players.Where(x => x.Nationality == nationality).ToList();
    }

    public List<Player> PlayersOlderThan(int age)
    {
        var players = _playerRepository.GetAll();
        var playersssss = players
            .OrderByDescending(x => x.DateOfBirth)
            .Where(x => ((DateTime.Now.Year - x.DateOfBirth.Year) > age))
            .ToList();

        return playersssss;
    }

    // FIRST, LAST, SINGLE
    public Player FirstByNationality(string nationality)
    {
        var players = _playerRepository.GetAll();
        return players.First(x => x.Nationality == nationality);
    }

    public Player FirstOrDefaultByNationality(string nationality)
    {
        var players = _playerRepository.GetAll();
        var player = players.FirstOrDefault(x => x.Nationality == nationality);
        if (player is null)
        {
            Console.WriteLine($"There's no player with nationality {nationality}.");
        }

        return player!;
    }

    public Player FirstOrDefaultByNationalityWithDefault(string nationality)
    {
        var players = _playerRepository.GetAll();
        return players
            .FirstOrDefault(
            x => x.Nationality == nationality,
            new Player { Id = -1, FirstName = "NOT FOUND" });
    }

    public Player LastByNationality(string nationality)
    {
        var players = _playerRepository.GetAll();
        return players.Last(x => x.Nationality == nationality);
    }

    public Player SingleById(int id)
    {
        var players = _playerRepository.GetAll();
        return players.Single(x => x.Id == id);
    }
    public Player SingleOrDefaultById(int id)
    {
        var players = _playerRepository.GetAll();
        var player = players.SingleOrDefault(x => x.Id == id);
        if (player is null)
        {
            Console.WriteLine($"Player with id {id} NOT FOUND");
        }
        return player!;
    }

    // TAKE
    public List<Player> TakePlayers(int howMany)
    {
        var players = _playerRepository.GetAll();
        return players
            .OrderByDescending(x => x.DateOfBirth)
            .Take(howMany)
            .ToList();
    }

    public List<Player> TakePlayers(Range range)
    {
        var players = _playerRepository.GetAll();
        return players
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Take(range)
            .ToList();
    }

    public List<Player> TakePlayersWhileBornAfter(DateTime date)
    {
        var players = _playerRepository.GetAll();
        return players
            .OrderByDescending(x => x.DateOfBirth)
            .TakeWhile(x => x.DateOfBirth >= date)
            //.TakeWhile((x, index) => x.LastName.StartsWith(prefix))
            .ToList();
    }

    public List<Player> TakePlayersWhileNameStartsWith(string prefix)
    {
        var players = _playerRepository.GetAll();
        return players
            .OrderBy(x => x.LastName)
            .TakeWhile(x => x.LastName!.StartsWith(prefix))
            .ToList();
    }

    //SKIP
    public List<Player> SkipPlayers(int howMany)
    {
        var players = _playerRepository.GetAll();
        return players
            .Skip(howMany)
            .ToList();
    }

    public List<Player> SkipPlayersWhileBornAfter(DateTime date)
    {
        var players = _playerRepository.GetAll();
        return players.OrderByDescending(x => x.DateOfBirth)
            .SkipWhile(x => x.DateOfBirth >= date)
            .ToList();
    }

    public List<Player> SkipPlayersWhileNameStartsWith(string prefix)
    {
        var players = _playerRepository.GetAll();
        return players
            .OrderBy(x => x.LastName)
            .SkipWhile(x => x.LastName!.StartsWith(prefix))
            .ToList();
    }

    // DISTINCT
    public List<string> DistinctAllNationalities()
    {
        var players = _playerRepository.GetAll();
        return players
            .Select(x => x.Nationality!)
            .Distinct()
            .OrderBy(x => x)
            .ToList();
    }

    public List<Player> DistinctByNationalities()
    {
        var players = _playerRepository.GetAll();
        return players
            .DistinctBy(x => x.Nationality)
            .OrderBy(x => x.Nationality)
            .ToList();
    }

    public List<Player[]> ChunkPlayers(int size)
    {
        var players = _playerRepository.GetAll();
        return players.Chunk(size).ToList();
    }
}

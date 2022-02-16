namespace FootballClubApp.Services;

public class DataGeneratorListRepository : DataGenerator, IDataGenerator
{
    private readonly IRepository<Player> _playerRepository;
    private readonly IRepository<Opponent> _opponentRepository;
    public DataGeneratorListRepository(IRepository<Player> playerRepository, IRepository<Opponent> opponentRepository)
    {
        _playerRepository = playerRepository;
        _opponentRepository = opponentRepository;
    }

    public override void ViewDataSourceInfo()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Data provider: JSON files.\n");
        Console.ResetColor();
    }

    public override void AddPlayers()
    {
        _playerRepository.Read(); // reading from json file

        if (_playerRepository.GetListCount() == 0)
        {
            var players = GetPlayers();

            _playerRepository.AddBatch(players);
        }
    }

    public override void AddOpponents()
    {
        _opponentRepository.Read(); // reading from json file

        if (_opponentRepository.GetListCount() == 0)
        {
            var opponents = GetOpponents();

            _opponentRepository.AddBatch(opponents);
        }
    }
}

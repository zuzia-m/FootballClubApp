namespace FootballClubApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<Player> _playerRepository;
    private readonly IRepository<Opponent> _opponentRepository;

    public EventHandlerService(IRepository<Player> playerRepository, IRepository<Opponent> opponentRepository)
    {
        _playerRepository = playerRepository;
        _opponentRepository = opponentRepository;
    }

    public void SubscribeToEvents()
    {
        _playerRepository.ItemAdded += PlayerRepositoryOnItemAdded;
        _playerRepository.ItemRemoved += PlayerRepositoryOnItemRemoved;
        _opponentRepository.ItemAdded += OpponentRepositoryOnItemAdded;
        _opponentRepository.ItemRemoved += OpponentRepositoryOnItemRemoved;
    }

    private void PlayerRepositoryOnItemAdded(object? sender, Player e)
    {
        AddAuditInfo(e, "PLAYER ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Player\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void PlayerRepositoryOnItemRemoved(object? sender, Player e)
    {
        AddAuditInfo(e, "PLAYER REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Player\n{e}\nremoved successfully.\n");
        Console.ResetColor();
    }

    private void OpponentRepositoryOnItemAdded(object? sender, Opponent e)
    {
        AddAuditInfo(e, "OPPONENT ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Opponent\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void OpponentRepositoryOnItemRemoved(object? sender, Opponent e)
    {
        AddAuditInfo(e, "OPPONENT REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Opponent\n{e}\nremoved successfully.\n");
        Console.ResetColor();
    }

    private void AddAuditInfo<T>(T e, string info) where T : class, IEntity
    {
        using (var writer = File.AppendText((IRepository<IEntity>.auditFileName)))
        {
            writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n    [{e}]");
        }
    }
}
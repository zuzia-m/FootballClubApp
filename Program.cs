using FootballClubApp.Repositories;
using FootballClubApp.Entities;
using FootballClubApp.Data;
using FootballClubApp.Repositories.Extensions;
using FootballClubApp;
using System.Linq;

static void PlayerRepositoryOnItemAdded(object? sender, Player e)
{
    AddAuditInfo(e, "PLAYER ADDED");
    WritelineColor($"Player [{e}] added successfully.", ConsoleColor.Green);
}

static void PlayerRepositoryOnItemRemoved(object? sender, Player e)
{
    AddAuditInfo(e, "PLAYER REMOVED");
    WritelineColor($"Player [{e}] removed successfully", ConsoleColor.Green);
}

static void OpponentRepositoryOnItemAdded(object? sender, Opponent e)
{
    AddAuditInfo(e, "OPPONENT ADDED");
    WritelineColor($"Opponent [{e}] added successfully.", ConsoleColor.Green);
}

static void OpponentRepositoryOnItemRemoved(object? sender, Opponent e)
{
    AddAuditInfo(e, "OPPONENT REMOVED");
    WritelineColor($"Opponent [{e}] removed successfully", ConsoleColor.Green);
}

WritelineColor("Hello to the [Football Club App] console app.\n\n", ConsoleColor.White, ConsoleColor.DarkMagenta);
Console.WriteLine("In this version of the application you can view, add, find and remove PLAYERS and OPPONENTS for:");
WritelineColor("----------------------------------- F C   B A R C E L O N A -----------------------------------\n\n", ConsoleColor.DarkRed, ConsoleColor.Blue);

var playerRepository = new ListRepository<Player>();
var opponentRepository = new ListRepository<Opponent>(); ;
ListRepositoryInitialization(playerRepository, opponentRepository);

//var playerRepository = new SqlRepository<Player>(new FootballClubAppDbContext());
//var opponentRepository = new SqlRepository<Opponent>(new FootballClubAppDbContext());
//SqlRepositoryInitialization(playerRepository, opponentRepository);

bool CloseApp = false;

while (!CloseApp)
{
    Console.WriteLine();
    WritelineColor("1 - View all entities\n" +
        "2 - Add new entity\n" +
        "3 - Find entity by id\n" +
        "4 - Remove entity from memory\n" +
        "X - Close the app and save changes\n", ConsoleColor.Cyan);

    var userInput = GetInputFromUser("What you want to do? \nPress key 1, 2, 3, 4 or X: ").ToUpper();

    switch (userInput)
    {
        case "1": // View all
            var userChoiceToShowAll = GetInputFromUser("P - View all PLAYERS\nO - View all OPPONENTS\nAny Other key - leave and go to MENU").ToUpper();
            if (userChoiceToShowAll == "P")
            {
                WriteAllToConsole(playerRepository);
                break;
            }
            if (userChoiceToShowAll == "O")
            {
                WriteAllToConsole(opponentRepository);
                break;
            }
            break;

        case "2": // Add new
            var userChoiceToAdd = GetInputFromUser("P - Add new PLAYER\nO - Add new OPPONENT\nQ - leave and go to MENU").ToUpper();
            if (userChoiceToAdd == "P")
            {
                AddNewPlayer(playerRepository);
                break;
            }
            if (userChoiceToAdd == "O")
            {
                AddNewOpponent(opponentRepository);
                break;
            }
            break;

        case "3": // Find by id
            var userChoiceToFind = GetInputFromUser("P - Find PLAYER by id\nO - Find OPPONENT by id\nQ - leave and go to MENU").ToUpper();
            if (userChoiceToFind == "P")
            {
                FindEntityById(playerRepository);
                break;
            }
            if (userChoiceToFind == "O")
            {
                FindEntityById(opponentRepository);
                break;
            }
            break;

        case "4": // Remove by id
            var userChoiceToRemove = GetInputFromUser("P - Remove PLAYER by id\nO - Remove OPPONENT by id\nQ - leave and go to MENU").ToUpper();
            if (userChoiceToRemove == "P")
            {
                RemoveEntity(playerRepository);
                break;
            }
            if (userChoiceToRemove == "O")
            {
                RemoveEntity(opponentRepository);
                break;
            }
            break;

        case "X": // Close app and Save changes
            CloseApp = CloseAppSaveChanges(playerRepository, opponentRepository);
            break;

        default:
            WritelineColor("Invalid operation.\n", ConsoleColor.Red);
            continue;
    }
}

WritelineColor("\n\nBye Bye! Press any key to leave.", ConsoleColor.DarkCyan);
Console.ReadKey();

static void ListRepositoryInitialization(ListRepository<Player> playerRepository, ListRepository<Opponent> opponentRepository)
{
    playerRepository.ItemAdded += PlayerRepositoryOnItemAdded;
    playerRepository.ItemRemoved += PlayerRepositoryOnItemRemoved;
    opponentRepository.ItemAdded += OpponentRepositoryOnItemAdded;
    opponentRepository.ItemRemoved += OpponentRepositoryOnItemRemoved;

    playerRepository.Read();
    opponentRepository.Read();
    if (playerRepository.GetListCount() == 0)
    {
        AddPlayers(playerRepository);
    }
    if (opponentRepository.GetListCount() == 0)
    {
        AddOpponents(opponentRepository);
    }
}

static void SqlRepositoryInitialization(SqlRepository<Player> playerRepository, SqlRepository<Opponent> opponentRepository)
{
    playerRepository.ItemAdded += PlayerRepositoryOnItemAdded;
    playerRepository.ItemRemoved += PlayerRepositoryOnItemRemoved;
    opponentRepository.ItemAdded += OpponentRepositoryOnItemAdded;
    opponentRepository.ItemRemoved += OpponentRepositoryOnItemRemoved;
}

static void WriteAllToConsole<T>(IRepository<T> repository) where T : class, IEntity
{
    WritelineColor("\n\n----- View all -----", ConsoleColor.Cyan);
    var items = repository.GetAll();
    if (items.ToList().Count == 0)
    {
        WritelineColor($"No objects found.", ConsoleColor.Red);
    }
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void AddNewPlayer(IRepository<Player> playerRepository)
{
    var firstName = GetInputFromUser("FirstName:");
    EmptyInputWarning(ref firstName, "FirstName:");
    var lastName = GetInputFromUser("LastName:");
    EmptyInputWarning(ref lastName, "LastName:");
    var number = GetInputFromUser("Number:");
    EmptyInputWarning(ref number, "Number:");
    while (true)
    {
        var position = GetInputFromUser("Player position:\tGoalkeeper: 1\tDefender: 2\tMidfielder: 3\tAttacker: 4");
        int positionValue;
        var isParsed = int.TryParse(position, out positionValue);
        if (isParsed && positionValue > 0 && positionValue <= 4)
        {
            while (true)
            {
                var choice = GetInputFromUser("Is this player the team captain?\nPress Y if YES\t\tPress N if NO").ToUpper();
                if (choice == "Y")
                {
                    var newPlayer = new Captain { FirstName = firstName, LastName = lastName, Number = number, Position = (Position)positionValue };
                    playerRepository.Add(newPlayer);
                    break;
                }
                if (choice == "N")
                {
                    var newPlayer = new Player { FirstName = firstName, LastName = lastName, Number = number, Position = (Position)positionValue };
                    playerRepository.Add(newPlayer);
                    break;
                }
                else
                {
                    WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
                }
            }
            break;
        }
        else
        {
            WritelineColor("Only '1', '2', '3' or '4' key can be used to enter the player's position. Try again.", ConsoleColor.Red);
        }
    }
}

static void AddNewOpponent(IRepository<Opponent> opponentRepository)
{
    var teamName = GetInputFromUser("Team Name:");
    while (true)
    {
        var competition = GetInputFromUser("Competition:\tLaLiga = 1\tCopaDelRey = 2\tChampionsLeague = 3\tEuropaLeague = 4");
        int competitionValue;
        var isParsed = int.TryParse(competition, out competitionValue);
        if (isParsed && competitionValue > 0 && competitionValue <= 4)
        {
            var newOpponent = new Opponent { TeamName = teamName, Competition = (Competition)competitionValue };
            opponentRepository.Add(newOpponent);
            break;
        }
        else
        {
            WritelineColor("Only '1', '2', '3' or '4' key can be used to enter the player's position. Try again.", ConsoleColor.Red);
        }
    }
}

static T? FindEntityById<T>(IRepository<T> entityRepository) where T : class, IEntity
{
    while (true)
    {
        var choiceID = GetInputFromUser($"Enter the ID of the {typeof(T).Name} you want to find:");
        int choiceIDValue;
        var isParsed = int.TryParse(choiceID, out choiceIDValue);
        if (!isParsed)
        {
            WritelineColor("Please enter the integer number for ID.", ConsoleColor.Red);
        }
        else
        {
            var entity = entityRepository.GetById(choiceIDValue);
            if (entity != null)
            {
                WritelineColor(entity.ToString(), ConsoleColor.Green);
            }
            return entity;
        }
    }
}

static void RemoveEntity<T>(IRepository<T> entityRepository) where T : class, IEntity
{
    var entityFound = FindEntityById(entityRepository);
    if (entityFound != null)
    {
        while (true)
        {
            WritelineColor($"Do you really want to remove this {typeof(T).Name}?", ConsoleColor.Red);
            var choice = GetInputFromUser("Press Y if YES\t\tPress N if NO").ToUpper();
            if (choice == "Y")
            {
                entityRepository.Remove(entityFound);
                break;
            }
            else if (choice == "N")
            {
                break;
            }
            else
            {
                WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
            }
        }
    }
}

static bool CloseAppSaveChanges(IRepository<Player> playerRepository, IRepository<Opponent> opponentRepository)
{
    while (true)
    {
        var choice = GetInputFromUser("Do you want to save changes?\nPress Y if YES\t\tPress N if NO").ToUpper();
        if (choice == "Y")
        {
            playerRepository.Save();
            opponentRepository.Save();
            WritelineColor("Changes successfully saved.", ConsoleColor.Green);
            return true;
        }
        else if (choice == "N")
        {
            return true;
        }
        else
        {
            WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
        }
    }
}

static void AddAuditInfo<T>(T e, string info) where T : class, IEntity
{
    using (var writer = File.AppendText(IRepository<IEntity>.auditFileName))
    {
        writer.WriteLine($"[{DateTime.UtcNow}]-----{info}-----[{e}]");
    }
}

static void WritelineColor(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = default)
{
    Console.ForegroundColor = foregroundColor;
    Console.BackgroundColor = backgroundColor;
    Console.WriteLine(text);
    Console.ResetColor();
}

static string GetInputFromUser(string comment)
{
    WritelineColor(comment, ConsoleColor.DarkYellow);
    string userInput = Console.ReadLine();
    return userInput;
}

static void EmptyInputWarning(ref string input, string inputName)
{
    while (String.IsNullOrEmpty(input))
    {
        WritelineColor($"This input can not be empty.", ConsoleColor.Red);
        input = GetInputFromUser($"{inputName}:");
    }
}

static void AddPlayers(IRepository<Player> playerRepository)
{
    var players = new[]
    {
        new Player { FirstName = "Ansu", LastName = "Fati", Number = "10", Position = Position.Attacker },
        new Player { FirstName = "Gerard", LastName = "Piqué", Number = "3", Position = Position.Defender },
        new Player { FirstName = "Marc-André", LastName = "ter Stegen", Number = "1", Position = Position.Goalkeeper },
        new Player { FirstName = "Pablo", LastName = "Gavi", Number = "30", Position = Position.Midfielder },
        new Captain { FirstName = "Sergio", LastName = "Busquets", Number = "5", Position = Position.Midfielder }
    };

    playerRepository.AddBatch(players);
}

static void AddOpponents(IRepository<Opponent> opponentRepository)
{
    var opponents = new[]
    {
        new Opponent { TeamName = "Real Madrid", Competition = Competition.LaLiga },
        new Opponent { TeamName = "Atletico Madrid", Competition = Competition.LaLiga },
        new Opponent { TeamName = "SSC Napoli", Competition = Competition.ChampionsLeague },
    };

    opponentRepository.AddBatch(opponents);
}
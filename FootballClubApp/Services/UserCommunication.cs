namespace FootballClubApp.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Player> _playerRepository;
    private readonly IRepository<Opponent> _opponentRepository;
    private readonly ISpecificInfoProvider _specificInfoProvider;

    public UserCommunication(IRepository<Player> playerRepository, IRepository<Opponent> opponentRepository, ISpecificInfoProvider specificInfoProvider)
    {
        _playerRepository = playerRepository;
        _opponentRepository = opponentRepository;
        _specificInfoProvider = specificInfoProvider;
    }

    public void ChooseWhatToDo()
    {
        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine();
            WritelineColor("--- MAIN MENU ---\n" +
                "1 - View all entities\n" +
                "2 - Add new entity\n" +
                "3 - Find entity by id\n" +
                "4 - Remove entity from memory\n" +
                "5 - Get specific information...\n" +
                "X - Close the app and save changes\n", ConsoleColor.Cyan);

            var userInput = GetInputFromUser("What you want to do? \nPress key 1, 2, 3, 4, 5 or X: ").ToUpper();

            switch (userInput)
            {
                case "1": // View all
                    var userChoiceToShowAll = GetInputFromUser("P - View all PLAYERS\nO - View all OPPONENTS\nAny Other key - leave and go to MENU").ToUpper();
                    if (userChoiceToShowAll == "P")
                    {
                        WriteAllToConsole(_playerRepository);
                        break;
                    }
                    if (userChoiceToShowAll == "O")
                    {
                        WriteAllToConsole(_opponentRepository);
                        break;
                    }
                    break;

                case "2": // Add new
                    var userChoiceToAdd = GetInputFromUser("P - Add new PLAYER\nO - Add new OPPONENT\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToAdd == "P")
                    {
                        AddNewPlayer();
                        break;
                    }
                    if (userChoiceToAdd == "O")
                    {
                        AddNewOpponent();
                        break;
                    }
                    break;

                case "3": // Find by id
                    var userChoiceToFind = GetInputFromUser("P - Find PLAYER by id\nO - Find OPPONENT by id\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToFind == "P")
                    {
                        FindEntityById(_playerRepository);
                        break;
                    }
                    if (userChoiceToFind == "O")
                    {
                        FindEntityById(_opponentRepository);
                        break;
                    }
                    break;

                case "4": // Remove by id
                    var userChoiceToRemove = GetInputFromUser("P - Remove PLAYER by id\nO - Remove OPPONENT by id\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToRemove == "P")
                    {
                        RemoveEntity(_playerRepository);
                        break;
                    }
                    if (userChoiceToRemove == "O")
                    {
                        RemoveEntity(_opponentRepository);
                        break;
                    }
                    break;

                case "5": // Get specific info...
                    _specificInfoProvider.GetSpecificInfo();
                    break;

                case "X": // Close app and Save changes
                    CloseApp = CloseAppSaveChanges();
                    break;

                default:
                    WritelineColor("Invalid operation.\n", ConsoleColor.Red);
                    continue;
            }
        }

        WritelineColor("\n\nBye Bye! Press any key to leave.", ConsoleColor.DarkCyan);
    }

    private void WriteAllToConsole<T>(IRepository<T> repository) where T : class, IEntity
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

    private void AddNewPlayer()
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
                        var newPlayer = new Player { FirstName = firstName, LastName = lastName, Number = number, Position = (Position)positionValue, IsCaptain = true };
                        _playerRepository.Add(newPlayer);
                        break;
                    }
                    if (choice == "N")
                    {
                        var newPlayer = new Player { FirstName = firstName, LastName = lastName, Number = number, Position = (Position)positionValue, IsCaptain = false };
                        _playerRepository.Add(newPlayer);
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

    private void AddNewOpponent()
    {
        var teamName = GetInputFromUser("Team Name:");
        EmptyInputWarning(ref teamName, "Team Name:");
        while (true)
        {
            var competition = GetInputFromUser("Competition:\tLaLiga = 1\tCopaDelRey = 2\tChampionsLeague = 3\tEuropaLeague = 4");
            int competitionValue;
            var isParsed = int.TryParse(competition, out competitionValue);
            if (isParsed && competitionValue > 0 && competitionValue <= 4)
            {
                var newOpponent = new Opponent { TeamName = teamName, Competition = (Competition)competitionValue };
                _opponentRepository.Add(newOpponent);
                break;
            }
            else
            {
                WritelineColor("Only '1', '2', '3' or '4' key can be used to enter the player's position. Try again.", ConsoleColor.Red);
            }
        }
    }

    private T? FindEntityById<T>(IRepository<T> entityRepository) where T : class, IEntity
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
                    WritelineColor(entity.ToString()!, ConsoleColor.Green);
                }
                return entity;
            }
        }
    }

    private void RemoveEntity<T>(IRepository<T> entityRepository) where T : class, IEntity
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

    private bool CloseAppSaveChanges()
    {
        while (true)
        {
            var choice = GetInputFromUser("Do you want to save changes?\nPress Y if YES\t\tPress N if NO").ToUpper();
            if (choice == "Y")
            {
                _playerRepository.Save();
                _opponentRepository.Save();
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
}
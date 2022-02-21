namespace FootballClubApp.Services;

public class SpecificInfoProvider : UserCommunicationBase, ISpecificInfoProvider
{
    private readonly IPlayerProvider _playerProvider;

    public SpecificInfoProvider(IPlayerProvider playerProvider)
    {
        _playerProvider = playerProvider;
    }

    public void GetSpecificInfo()
    {
        bool closeLoop = false;

        while (!closeLoop)
        {
            Console.WriteLine();
            WritelineColor(
                "--- WHAT KIND OF INFORMATION YOU WANT TO VIEW ---\n" +
                "1 - Get unique <Nationalities>\n" +
                "2 - Get max <Market value>\n" +
                "3 - Order players by <Age and Nationality>\n" +
                "4 - Order players by <Weekly Wage>\n" +
                "5 - Order players by <Contract to>\n" +
                "6 - Order players by <LastName and FirstName>\n" +
                "7 - Players where <Weekly Wage> is greater than...\n" +
                "8 - Players older than <Age>\n" +
                "X - Back to MAIN MENU\n", ConsoleColor.DarkCyan);

            var userInput = GetInputFromUser("What you want to do? \nPress key 1, 2, 3, 4, 5, 6, 7, 8, 9 or X: ").ToUpper();

            switch (userInput)
            {
                case "1": // Get unique <Nationalities>
                    GetUniqueNationalities();
                    break;

                case "2": // Get max <Market value>
                    GetMaxMarketValue();
                    break;

                case "3": // Order players by <Age and Nationality>
                    OrderPlayersByAgeAndNationality();
                    break;

                case "4": // Order players by <Weekly Wage>
                    OrderPlayersByWeeklyWage();
                    break;

                case "5": // Order players by <Contract to>
                    OrderPlayersByContractTo();
                    break;

                case "6": // Order players by <LastName and FirstName>
                    OrderOlayersByLastNameAndFirstName();
                    break;

                case "7": // Players where <Weekly Wage> is greater than...
                    GetPlayersWhereWeeklyWageIsGreaterThan();
                    break;

                case "8": // Players older than <Age>
                    GetPlayersOlderThanAge();
                    break;

                case "X":
                    closeLoop = true;
                    break;

                default:
                    WritelineColor("Invalid operation.\n", ConsoleColor.Red);
                    continue;
            }
        }
    }

    private void GetPlayersOlderThanAge()
    {
        WritelineColor("Players <OlderThan>", ConsoleColor.DarkCyan);
        string input2 = GetInputFromUser("Enter the <Age> value (integer number)");
        int value2;
        bool isParsed2 = int.TryParse(input2, out value2);
        if (isParsed2)
        {
            var playersOlderThan = _playerProvider.PlayersOlderThan(value2);
            foreach (var player in playersOlderThan)
            {
                Console.WriteLine($"{player.FirstName} {player.LastName}  -  {(DateTime.Now - player.DateOfBirth).Days / 365}");
            }
        }
        else
        {
            WritelineColor("The input <Age> has to be integer number", ConsoleColor.Red);
        }
    }

    private void GetPlayersWhereWeeklyWageIsGreaterThan()
    {
        WritelineColor("Players where <Weekly Wage> is greater than...", ConsoleColor.DarkCyan);
        string input = GetInputFromUser("Enter the limit <Weekly Wage> value (integer number)");
        int value;
        bool isParsed = int.TryParse(input, out value);
        if (isParsed)
        {
            var minMarkerWeeklyWage = _playerProvider.PlayersMinWeeklyWage(value);
            foreach (var player in minMarkerWeeklyWage)
            {
                Console.WriteLine($"{player.FirstName} {player.LastName} - {(player.WeeklyWage).ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} €");
            }
        }
        else
        {
            WritelineColor("The input <Weekly Wage> has to be integer number", ConsoleColor.Red);
        }
    }

    private void OrderOlayersByLastNameAndFirstName()
    {
        WritelineColor("Order players by <LastName and FirstName>", ConsoleColor.DarkCyan);
        var orderedPLayers = _playerProvider.OrderByLastNameAndFirstName();
        foreach (var player in orderedPLayers)
        {
            Console.WriteLine(player);
        }
    }

    private void OrderPlayersByContractTo()
    {
        WritelineColor("Order players by <Contract to>", ConsoleColor.DarkCyan);
        var playersByContractTo = _playerProvider.OrderByContractTo();
        foreach (var player in playersByContractTo)
        {
            Console.WriteLine(player);
        }
    }

    private void OrderPlayersByWeeklyWage()
    {
        WritelineColor("Order players by <Weekly Wage>", ConsoleColor.DarkCyan);
        var playersByWeeklyWage = _playerProvider.OrderByWeeklyWage();
        foreach (var player in playersByWeeklyWage)
        {
            Console.WriteLine(player);
        }
    }

    private void OrderPlayersByAgeAndNationality()
    {
        WritelineColor("Order players by <Age and Nationality>:", ConsoleColor.DarkCyan);
        var playersByAgeAndNationality = _playerProvider.OrderByAgeAndNationality();
        foreach (var player in playersByAgeAndNationality)
        {
            Console.WriteLine($"{player.FirstName} {player.LastName}  -  {(DateTime.Now - player.DateOfBirth).Days / 365}  -  {player.Nationality}");
        }
    }

    private void GetMaxMarketValue()
    {
        WritelineColor("Max <Market value>:", ConsoleColor.DarkCyan);
        Console.WriteLine($"\nMaximum Market Value: {_playerProvider.GetMaximumMarketValue().ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} €");
    }

    private void GetUniqueNationalities()
    {
        WritelineColor("Unique <Nationalities>:", ConsoleColor.DarkCyan);
        Console.ResetColor();
        var nationalities = _playerProvider.GetUniqueNationality();
        foreach (var nationality in nationalities)
        {
            Console.WriteLine(nationality);
        }
    }
}


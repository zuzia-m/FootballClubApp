namespace FootballClubApp.Services;

public class App : IApp
{
    private readonly IDataGenerator _dataProvider;
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandlerService _eventHandlerService;

    public App(IDataGenerator dataProvider, IUserCommunication userCommunication, IEventHandlerService eventHandlerService)
    {
        _dataProvider = dataProvider;
        _userCommunication = userCommunication;
        _eventHandlerService = eventHandlerService;
    }
    public void Run()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Hello to the [Football Club App] console app.\n\n");
        Console.ResetColor();
        Console.WriteLine("In this version of the application you can view, add, find and remove PLAYERS and OPPONENTS for:");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("----------------------------------- F C   B A R C E L O N A -----------------------------------\n");
        Console.ResetColor();

        _eventHandlerService.SubscribeToEvents();

        _dataProvider.ViewDataSourceInfo();
        _dataProvider.AddPlayers();
        _dataProvider.AddOpponents();

        _userCommunication.ChooseWhatToDo();
    }
}

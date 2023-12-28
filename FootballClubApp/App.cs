namespace FootballClubApp;

public class App : IApp // main app
{
    private readonly IDataGenerator _dataGenerator;
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandlerService _eventHandlerService;

    public App(IDataGenerator dataGenerator, IUserCommunication userCommunication, IEventHandlerService eventHandlerService)
    {
        _dataGenerator = dataGenerator;
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

        _dataGenerator.ViewDataSourceInfo();
        _dataGenerator.AddPlayers();
        _dataGenerator.AddOpponents();

        _userCommunication.ChooseWhatToDo();
    }
}

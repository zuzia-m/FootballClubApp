namespace FootballClubApp.Services;

public abstract class UserCommunicationBase
{
    protected void WritelineColor(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = default)
    {
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    protected string GetInputFromUser(string comment)
    {
        WritelineColor(comment, ConsoleColor.DarkYellow);
        return Console.ReadLine()!;
    }

    protected void EmptyInputWarning(ref string? input, string inputName)
    {
        while (String.IsNullOrEmpty(input))
        {
            WritelineColor($"This input can not be empty.", ConsoleColor.Red);
            input = GetInputFromUser($"{inputName}:");
        }
    }
}
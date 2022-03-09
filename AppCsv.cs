namespace FootballClubApp;

public class AppCsv : IApp
{
    private readonly ICsvDataProvider _csvDataProvider;

    public AppCsv(ICsvDataProvider csvDataProvider)
    {
        _csvDataProvider = csvDataProvider;
    }

    public void Run()
    {
        _csvDataProvider.GenerateDataFromCsvFile();
    }
}

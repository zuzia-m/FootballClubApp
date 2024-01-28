namespace FootballClubApp.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacture> ProcessManufactures(string filePath);
}
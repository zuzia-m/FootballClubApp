using FootballClubApp.Components.CsvReader.Extensions;

namespace FootballClubApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Car>();
        }

        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToCar();

        return cars.ToList();
    }

    public List<Manufacture> ProcessManufactures(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacture>();
        }

        var manufactures = File.ReadAllLines(filePath)
            .Where(x => x.Length > 1)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacture()
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2])
                };
            });

        return manufactures.ToList();
    }
}
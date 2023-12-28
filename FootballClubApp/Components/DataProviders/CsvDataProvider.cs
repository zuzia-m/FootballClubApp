namespace FootballClubApp.Components.DataProviders;

public class CsvDataProvider : ICsvDataProvider
{
    private readonly ICsvReader _csvReader;

    public CsvDataProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void GenerateDataFromCsvFile()
    {
        var cars = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturers = _csvReader.ProcessManufactures(@"Resources\Files\manufacturers.csv");

        // GroupBy
        GroupManufacturersByName(cars);

        // Join
        JoinManufacturersAndCars(cars, manufacturers);

        // GroupJoin
        JoinManufacturersAndCarsGroupByManufacturer(cars, manufacturers);
    }

    private void JoinManufacturersAndCarsGroupByManufacturer(List<Car> cars, List<Manufacture> manufacturers)
    {
        var groupsJoined = manufacturers.GroupJoin(
            cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                }
            )
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var car in groupsJoined)
        {
            Console.WriteLine($" {car.Manufacturer.Name}");
            Console.WriteLine($"\t Cars: {car.Cars.Count()}");
            Console.WriteLine($"\t Max: {car.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t Min: {car.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t Avg: {car.Cars.Average(x => x.Combined)}");
            Console.WriteLine();
        }
    }

    private static void JoinManufacturersAndCars(List<Car> cars, List<Manufacture> manufacturers)
    {
        var carsInCountry = cars.Join(
            manufacturers,
            c => c.Manufacturer,
            m => m.Name,
            (car, manufacturer) => new
            {
                manufacturer.Country,
                car.Manufacturer,
                car.Name,
                car.Combined
            })
            .OrderByDescending(x => x.Name)
            .ThenBy(x => x.Name);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country: {car.Country}");
            Console.WriteLine($"\t Name: {car.Manufacturer} {car.Name}");
            Console.WriteLine($"\t Combined: {car.Combined}");
        }
    }

    private void GroupManufacturersByName(List<Car> cars)
    {
        var groups = cars.GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Min = g.Min(c => c.Combined),
                Average = Math.Round(g.Average(c => c.Combined), 2)
            })
            .OrderBy(x => x.Name);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\tcombined max: {group.Max}");
            Console.WriteLine($"\tcombined min: {group.Min}");
            Console.WriteLine($"\tcombined avr: {group.Average}");
        }
    }
}

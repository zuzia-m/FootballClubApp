using System.Xml.Linq;

namespace FootballClubApp.Components.CsvReader;

public class XmlCreator : IXmlCreator
{
    private readonly ICsvReader _csvReader;
    public XmlCreator(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void CreateXml()
    {
        var carsRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");

        var document = new XDocument();
        var cars = new XElement("Cars", carsRecords
            .Select(x =>
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufacturer", x.Manufacturer))));

        document.Add(cars);
        document.Save("fuel.xml");
    }

    public void QueryXml()
    {
        var document = XDocument.Load("fuel.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void CreateXmlJoined()
    {
        var carsRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturersRecords = _csvReader.ProcessManufactures(@"Resources\Files\manufacturers.csv");

        var groupsJoined = manufacturersRecords.GroupJoin(
            carsRecords,
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

        var document = new XDocument();

        var manufacturers = new XElement("Manufacturers", groupsJoined
            .Select(x =>
                new XElement("Manufacturer",
                    new XAttribute("Name", x.Manufacturer.Name),
                    new XAttribute("Country", x.Manufacturer.Country),
                        new XElement("Cars",
                            new XAttribute("Country", x.Manufacturer.Country),
                            new XAttribute("CombinedSum", x.Cars.Sum(c => c.Combined)),
                                new XElement("Car", x.Cars
                                    .Select(c =>
                                   new XElement("Car",
                                       new XAttribute("Model", c.Name),
                                       new XAttribute("Combined", c.Combined))))))));

        document.Add(manufacturers);
        document.Save("fuel2.xml");
    }
}

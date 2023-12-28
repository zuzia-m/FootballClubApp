using System.Xml.Linq;

namespace FootballClubApp;

public class AppXml : IApp
{
    private readonly IXmlCreator _xmlCreator;

    public AppXml(IXmlCreator xmlCreator)
    {
        _xmlCreator = xmlCreator;
    }

    public void Run()
    {
        _xmlCreator.CreateXml();
        _xmlCreator.CreateXmlJoined();
    }
}
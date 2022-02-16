namespace FootballClubApp.Services;

public abstract class DataProvider : IDataProvider
{
    public abstract void ViewDataProviderInfo();
    public abstract void AddOpponents();
    public abstract void AddPlayers();

    protected IEnumerable<Player> GetPlayers()
    {
        var players = new List<Player>()
            {
                new Player { FirstName = "Ansu", LastName = "Fati", Number = "10", Position = Position.Attacker },
                new Player { FirstName = "Gerard", LastName = "Piqué", Number = "3", Position = Position.Defender },
                new Player { FirstName = "Marc-André", LastName = "ter Stegen", Number = "1", Position = Position.Goalkeeper },
                new Player { FirstName = "Pablo", LastName = "Gavi", Number = "30", Position = Position.Midfielder },
                new Captain { FirstName = "Sergio", LastName = "Busquets", Number = "5", Position = Position.Midfielder }
            };

        return players;
    }

    protected IEnumerable<Opponent> GetOpponents()
    {
        var opponents = new List<Opponent>()
            {
                new Opponent { TeamName = "Real Madrid", Competition = Competition.LaLiga },
                new Opponent { TeamName = "Atletico Madrid", Competition = Competition.LaLiga },
                new Opponent { TeamName = "SSC Napoli", Competition = Competition.ChampionsLeague },
            };

        return opponents;
    }
}

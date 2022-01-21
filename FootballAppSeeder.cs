using FootballClubApp.Entities;
using FootballClubApp.Repositories;
using FootballClubApp.Repositories.Extensions;
using FootballClubApp.Data;
using System.Collections.Generic;

namespace FootballClubApp
{
    public class FootballAppSeeder
    {
        private readonly FootballClubAppDbContext _dbContext;
        public FootballAppSeeder(FootballClubAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Players.Any())
                {
                    var players = GetPlayers();
                    _dbContext.Players.AddRange(players);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Opponents.Any())
                {
                    var opponents = GetOpponents();
                    _dbContext.Opponents.AddRange(opponents);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Player> GetPlayers()
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

        private IEnumerable<Opponent> GetOpponents()
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
}

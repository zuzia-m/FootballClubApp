namespace FootballClubApp.Services;

public abstract class DataGenerator : IDataGenerator
{
    public abstract void ViewDataSourceInfo();

    public abstract void AddOpponents();

    public abstract void AddPlayers();

    protected IEnumerable<Player> GetPlayers()
    {
        var players = new List<Player>()
            {
                new Player()
                    {
                        FirstName = "Marc André",
                        LastName = "Ter Stegen",
                        Number = "1",
                        Position = Position.Goalkeeper,
                        Nationality = "Germany",
                        MarketValue = 45_000_000m,
                        WeeklyWage = 150_000m,
                        DateOfBirth = new DateTime(1992, 04, 30),
                        ContractTo = new DateTime(2025, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Neto",
                        LastName = "Murara",
                        Number = "13",
                        Position = Position.Goalkeeper,
                        Nationality = "Brazil",
                        MarketValue = 4_000_000m,
                        WeeklyWage = 30_000m,
                        DateOfBirth = new DateTime(1989, 07, 19),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Ronald",
                        LastName = "Araújo",
                        Number = "4",
                        Position = Position.Defender,
                        Nationality = "Uruguay",
                        MarketValue = 35_000_000m,
                        WeeklyWage = 50_000m,
                        DateOfBirth = new DateTime(1999, 03, 07),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Eric",
                        LastName = "García",
                        Number = "24",
                        Position = Position.Defender,
                        Nationality = "Spain",
                        MarketValue = 18_000_000m,
                        WeeklyWage = 65_000m,
                        DateOfBirth = new DateTime(2001, 01, 09),
                        ContractTo = new DateTime(2026, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Clément",
                        LastName = "Lenglet",
                        Number = "15",
                        Position = Position.Defender,
                        Nationality = "France",
                        MarketValue = 14_000_000m,
                        WeeklyWage = 60_000m,
                        DateOfBirth = new DateTime(1995, 06, 17),
                        ContractTo = new DateTime(2026, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Óscar",
                        LastName = "Mingueza",
                        Number = "22",
                        Position = Position.Defender,
                        Nationality = "Spain",
                        MarketValue = 9_000_000m,
                        WeeklyWage = 40_000m,
                        DateOfBirth = new DateTime(1999, 05, 13),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Gerard",
                        LastName = "Piqué",
                        Number = "3",
                        Position = Position.Defender,
                        Nationality = "Spain",
                        MarketValue = 5_000_000m,
                        WeeklyWage = 160_000m,
                        DateOfBirth = new DateTime(1987, 02, 02),
                        ContractTo = new DateTime(2024, 06, 30),
                        IsCaptain = true
                    },

                new Player()
                    {
                        FirstName = "Samuel",
                        LastName = "Umtiti",
                        Number = "23",
                        Position = Position.Defender,
                        Nationality = "France",
                        MarketValue = 2_000_000m,
                        WeeklyWage = 200_000m,
                        DateOfBirth = new DateTime(1993, 11, 14),
                        ContractTo = new DateTime(2026, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Jordi",
                        LastName = "Alba",
                        Number = "18",
                        Position = Position.Defender,
                        Nationality = "Spain",
                        MarketValue = 12_000_000m,
                        WeeklyWage = 150_000m,
                        DateOfBirth = new DateTime(1989, 03, 21),
                        ContractTo = new DateTime(2024, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Álex",
                        LastName = "Balde",
                        Number = "31",
                        Position = Position.Defender,
                        Nationality = "Spain",
                        MarketValue = 5_000_000m,
                        WeeklyWage = 30_000m,
                        DateOfBirth = new DateTime(2003, 10, 18),
                        ContractTo = new DateTime(2024, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Sergiño",
                        LastName = "Dest",
                        Number = "2",
                        Position = Position.Defender,
                        Nationality = "USA",
                        MarketValue = 18_000_000m,
                        WeeklyWage = 40_000m,
                        DateOfBirth = new DateTime(2000, 11, 03),
                        ContractTo = new DateTime(2025, 06, 30),
                        IsCaptain = false
                    },

                new Player()
                    {
                        FirstName = "Dani",
                        LastName = "Alves",
                        Number = "8",
                        Position = Position.Defender,
                        Nationality = "Brazil",
                        MarketValue = 1_000_000m,
                        WeeklyWage = 10_000m,
                        DateOfBirth = new DateTime(1983, 05, 06),
                        ContractTo = new DateTime(2022, 06, 30),
                        IsCaptain = false
                    },

                 new Player()
                    {
                        FirstName = "Sergio",
                        LastName = "Busquets",
                        Number = "5",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 9_000_000m,
                        WeeklyWage = 100_000m,
                        DateOfBirth = new DateTime(1988, 07, 16),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = true
                    },

                  new Player()
                    {
                        FirstName = "Pedri",
                        LastName = "González",
                        Number = "16",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 80_000_000m,
                        WeeklyWage = 140_000m,
                        DateOfBirth = new DateTime(2002, 11, 25),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Frankie",
                        LastName = "de Jong",
                        Number = "21",
                        Position = Position.Midfielder,
                        Nationality = "Netherlands",
                        MarketValue = 70_000_000m,
                        WeeklyWage = 180_000m,
                        DateOfBirth = new DateTime(1997, 05, 12),
                        ContractTo = new DateTime(2026, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Pablo ",
                        LastName = "Gavi",
                        Number = "30",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 40_000_000m,
                        WeeklyWage = 30_000m,
                        DateOfBirth = new DateTime(2004, 08, 05),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Nico",
                        LastName = "González",
                        Number = "14",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 20_000_000m,
                        WeeklyWage = 70_000m,
                        DateOfBirth = new DateTime(2002, 01, 03),
                        ContractTo = new DateTime(2024, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Riqui",
                        LastName = "Puig",
                        Number = "6",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 9_000_000m,
                        WeeklyWage = 60_000m,
                        DateOfBirth = new DateTime(1991, 08, 13),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Sergi",
                        LastName = "Roberto",
                        Number = "20",
                        Position = Position.Midfielder,
                        Nationality = "Spain",
                        MarketValue = 9_000_000m,
                        WeeklyWage = 120_000m,
                        DateOfBirth = new DateTime(1992, 02, 07),
                        ContractTo = new DateTime(2022, 06, 30),
                        IsCaptain = true
                    },

                  new Player()
                    {
                        FirstName = "Ansu",
                        LastName = "Fati",
                        Number = "10",
                        Position = Position.Attacker,
                        Nationality = "Spain",
                        MarketValue = 60_000_000m,
                        WeeklyWage = 130_000m,
                        DateOfBirth = new DateTime(2002, 10, 31),
                        ContractTo = new DateTime(2027, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Ferran",
                        LastName = "Torres",
                        Number = "19",
                        Position = Position.Attacker,
                        Nationality = "Spain",
                        MarketValue = 45_000_000m,
                        WeeklyWage = 140_000m,
                        DateOfBirth = new DateTime(2000, 02, 29),
                        ContractTo = new DateTime(2027, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Ousmane",
                        LastName = "Dembélé",
                        Number = "7",
                        Position = Position.Attacker,
                        Nationality = "France",
                        MarketValue = 30_000_000m,
                        WeeklyWage = 220_000m,
                        DateOfBirth = new DateTime(1997, 05, 15),
                        ContractTo = new DateTime(2022, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Adama",
                        LastName = "Traoré",
                        Number = "11",
                        Position = Position.Attacker,
                        Nationality = "Spain",
                        MarketValue = 28_000_000m,
                        WeeklyWage = 100_000m,
                        DateOfBirth = new DateTime(1996, 01, 25),
                        ContractTo = new DateTime(2022, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Memphis",
                        LastName = "Depay",
                        Number = "9",
                        Position = Position.Attacker,
                        Nationality = "Netherlands",
                        MarketValue = 45_000_000m,
                        WeeklyWage = 140_000m,
                        DateOfBirth = new DateTime(1994, 02, 13),
                        ContractTo = new DateTime(2023, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Pierre-Emerick",
                        LastName = "Aubameyang",
                        Number = "25",
                        Position = Position.Attacker,
                        Nationality = "Gabon",
                        MarketValue = 15_000_000m,
                        WeeklyWage = 80_000m,
                        DateOfBirth = new DateTime(1989, 06, 18),
                        ContractTo = new DateTime(2025, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Martin",
                        LastName = "Braithwaite",
                        Number = "12",
                        Position = Position.Attacker,
                        Nationality = "Denmark",
                        MarketValue = 7_500_000m,
                        WeeklyWage = 70_000m,
                        DateOfBirth = new DateTime(1991, 06, 05),
                        ContractTo = new DateTime(2024, 06, 30),
                        IsCaptain = false
                    },

                  new Player()
                    {
                        FirstName = "Luuk",
                        LastName = "de Jong",
                        Number = "12",
                        Position = Position.Attacker,
                        Nationality = "Denmark",
                        MarketValue = 4_000_000m,
                        WeeklyWage = 30_000m,
                        DateOfBirth = new DateTime(1990, 08, 27),
                        ContractTo = new DateTime(2022, 06, 30),
                        IsCaptain = false
                    }
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
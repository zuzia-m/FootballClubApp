namespace FootballClubApp.Components.DataProviders;

public interface IPlayerProvider
{
    // SELECT
    List<string> GetUniqueNationality();
    decimal GetMinimumWeeklyWage();
    decimal GetMaximumMarketValue();
    List<Player> GetSpecificColumns();
    string AnonymousClass();

    // ORDER BY
    List<Player> OrderByLastNameAndFirstName();
    List<Player> OrderByLastNameAndFirstNameDescending();
    List<Player> OrderByAgeAndNationality();
    List<Player> OrderByWeeklyWage();
    List<Player> OrderByContractTo();

    // WHERE
    List<Player> PlayersMinMarketValue(decimal minMarketValue);
    List<Player> PlayersMinWeeklyWage(decimal minWeeklyWage);
    List<Player> WhereStartsWith(string prefix);
    List<Player> WhereStartsWithAndSalaryIsGreaterThan(string prefix, decimal salary);
    List<Player> WhereNationalityIs(string nationality);
    List<Player> PlayersOlderThan(int age);

    // FIRST, LAST, SINGLE
    Player FirstByNationality(string nationality);
    Player FirstOrDefaultByNationality(string nationality);
    Player FirstOrDefaultByNationalityWithDefault(string nationality);
    Player LastByNationality(string nationality);
    Player SingleById(int id);
    Player SingleOrDefaultById(int id);

    // TAKE
    List<Player> TakePlayers(int howMany);
    List<Player> TakePlayers(Range range);
    List<Player> TakePlayersWhileBornAfter(DateTime date);
    List<Player> TakePlayersWhileNameStartsWith(string prefix);

    // SKIP
    List<Player> SkipPlayers(int howMany);
    List<Player> SkipPlayersWhileBornAfter(DateTime date);
    List<Player> SkipPlayersWhileNameStartsWith(string prefix);

    // DISTINCT
    List<string> DistinctAllNationalities();
    List<Player> DistinctByNationalities();

    // CHUNK
    List<Player[]> ChunkPlayers(int size);
}

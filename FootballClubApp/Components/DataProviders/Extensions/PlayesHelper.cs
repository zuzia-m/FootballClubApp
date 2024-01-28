namespace FootballClubApp.Components.DataProviders.Extensions;

public static class PlayesHelper
{
    public static IEnumerable<Player> ByNationality(this IEnumerable<Player> query, string nationality)
    {
        return query.Where(x => x.Nationality == nationality);
    }
}
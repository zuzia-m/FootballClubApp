namespace FootballClubApp.Data.Entities.Extensions;

using FootballClubApp.Data.Entities;
using System.Text.Json;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : class, IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}
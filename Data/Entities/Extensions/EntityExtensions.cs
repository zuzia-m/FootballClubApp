namespace FootballClubApp.Data.Entities.Extensions;

using System.Text.Json;
using FootballClubApp.Data.Entities;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : class, IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}


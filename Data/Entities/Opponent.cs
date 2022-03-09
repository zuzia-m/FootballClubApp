namespace FootballClubApp.Data.Entities;

public class Opponent : EntityBase
{
    public string? TeamName { get; set; }
    public Competition Competition { get; set; }
    public override string ToString() => $"Id: {Id}, TeamName: {TeamName}, Competition: {Competition}";
}

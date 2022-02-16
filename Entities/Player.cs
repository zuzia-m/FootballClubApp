namespace FootballClubApp.Entities;

public class Player : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Number { get; set; }
    public Position Position { get; set; }
    public bool IsCaptain { get; set; }
    public Player()
    {
        IsCaptain = false;
    }
    public override string ToString()
    {
        return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Position: {Position}, Number: {Number}";
    }
}

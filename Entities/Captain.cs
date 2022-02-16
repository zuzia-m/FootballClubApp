namespace FootballClubApp.Entities;

public class Captain : Player
{
    public Captain()
    {
        IsCaptain = true;
    }

    public override string ToString() => base.ToString() + " (Team Captain)";
}

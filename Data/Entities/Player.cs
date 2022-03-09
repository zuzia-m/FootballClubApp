namespace FootballClubApp.Data.Entities;

public class Player : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Number { get; set; }
    public Position Position { get; set; }
    public string? Nationality { get; set; }
    public bool IsCaptain { get; set; }
    public decimal MarketValue { get; set; }
    public decimal WeeklyWage { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime ContractTo { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"Id. {Id}");
        sb.AppendLine($"    FirstName {FirstName}   LastName: {LastName}");
        sb.AppendLine($"    Position: {Position}    Number: {Number}    Nationality: {Nationality}");
        sb.AppendLine($"    Age: {DateTime.Now.Year - DateOfBirth.Year}     Date of birth: {DateOfBirth.ToShortDateString()}");
        sb.AppendLine($"    Marker Value: {MarketValue.ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} €   " +
                            $"Weekly Wage: {WeeklyWage.ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} €");
        sb.Append($"    ContractTo: {ContractTo.ToShortDateString()}");

        if (IsCaptain is true)
        {
            sb.Append($"\n    Team Captain");
        }
        return sb.ToString();
    }
}

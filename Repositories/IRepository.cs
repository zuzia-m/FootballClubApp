namespace FootballClubApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
    public const string auditFileName = "audit.txt";
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
}
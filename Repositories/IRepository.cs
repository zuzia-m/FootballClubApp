namespace FootballClubApp.Repositories;

using FootballClubApp.Entities;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
    public readonly static string auditFileName = "audit.txt";
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
}


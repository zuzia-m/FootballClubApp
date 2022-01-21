namespace FootballClubApp.Repositories;

using FootballClubApp.Entities;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
}
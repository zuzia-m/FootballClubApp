namespace FootballClubApp.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FootballClubApp.Entities;
using FootballClubApp.Data;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly FootballClubAppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    private readonly FootballAppSeeder _seeder;

    public SqlRepository(FootballClubAppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _seeder = new FootballAppSeeder(dbContext);
        _seeder.Seed();
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
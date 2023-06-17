using System.Linq.Expressions;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Implementations;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly ILogger<T> Logger;
    protected readonly DbSet<T> Entities;

    protected RepositoryBase(AppDbContext context, ILogger<T> logger)
    {
        Context = context;
        Logger = logger;
        Entities = context.Set<T>();
    }


    public virtual async Task<IEnumerable<T>> All()
    {
        return await Entities.ToListAsync();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await Entities.FindAsync(id);
    }

    public virtual async Task Add(T entity)
    {
        await Entities.AddAsync(entity);
    }

    public virtual async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        if (entity != null) Entities.Remove(entity);
    }

    public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await Entities.Where(predicate).ToListAsync();
    }
}
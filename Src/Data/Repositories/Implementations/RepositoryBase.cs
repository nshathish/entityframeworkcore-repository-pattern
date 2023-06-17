using System.Linq.Expressions;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Implementations;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly ILogger<T> Logger;
    protected DbSet<T> Entities;

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

    public virtual async Task<bool> Add(T entity)
    {
        await Entities.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await Entities.Where(predicate).ToListAsync();
    }
}
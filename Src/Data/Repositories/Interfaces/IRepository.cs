using System.Linq.Expressions;

namespace Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

    Task Add(T entity);
    Task Delete(Guid id);
}
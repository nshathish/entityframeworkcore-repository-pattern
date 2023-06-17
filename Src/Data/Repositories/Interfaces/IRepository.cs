using System.Linq.Expressions;

namespace Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(Guid id);
    Task<bool> Add(T entity);
    Task<bool> Delete(Guid id);
    Task<bool> Update(T entity);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
}
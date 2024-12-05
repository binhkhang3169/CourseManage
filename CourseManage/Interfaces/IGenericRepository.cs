using System.Linq.Expressions;

namespace CourseManage.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetWithFilterAndIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task SaveAsync();
}
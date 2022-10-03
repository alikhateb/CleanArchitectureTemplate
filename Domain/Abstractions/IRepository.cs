using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> conditionExpression);

        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> conditionExpression,
            params Expression<Func<T, object>>[] navigationProperties);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> conditionExpression);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> conditionExpression,
            params Expression<Func<T, object>>[] navigationProperties);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}

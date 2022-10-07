namespace Domain.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetList(ISpecification<T> specification = default);
    Task<T> Find(ISpecification<T> specification = default);

    //Task<IEnumerable<T>> GetListAsync();

    //Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> criteria);

    //Task<IEnumerable<T>> GetListAsync(List<Expression<Func<T, object>>> includes);

    //Task<IEnumerable<T>> GetListAsync(
    //    Expression<Func<T, bool>> criteria,
    //    List<Expression<Func<T, object>>> includes);

    //Task<T> FindAsync(Expression<Func<T, bool>> criteria);

    //Task<T> FindAsync(
    //    Expression<Func<T, bool>> criteria,
    //    List<Expression<Func<T, object>>> includes);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);

    Task UpdateRangeAsync(IEnumerable<T> entities);

    Task DeleteAsync(T entity);

    Task DeleteRangeAsync(IEnumerable<T> entities);
}
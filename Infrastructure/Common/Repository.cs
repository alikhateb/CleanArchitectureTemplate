using Domain.Abstractions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetList(ISpecification<T> specification = default)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (specification?.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification?.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (specification?.OrderByDescending is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        if (specification?.Includes is not null)
        {
            query = specification.Includes
                .Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
        }

        return query;
    }

    public async Task<T> Find(ISpecification<T> specification = default)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (specification?.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification?.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (specification?.OrderByDescending is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        if (specification?.Includes is not null)
        {
            query = specification.Includes
                .Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
        }

        return await query.SingleOrDefaultAsync();
    }


    //public async Task<IEnumerable<T>> GetListAsync()
    //{
    //    return _context.Set<T>().AsNoTracking();
    //}

    //public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> criteria)
    //{
    //    if (criteria is null)
    //    {
    //        throw new ArgumentNullException("arguments must be not null");
    //    }

    //    return _context.Set<T>()
    //        .Where(criteria)
    //        .AsNoTracking();
    //}

    //public async Task<IEnumerable<T>> GetListAsync(List<Expression<Func<T, object>>> includes)
    //{
    //    if (includes is null)
    //    {
    //        throw new ArgumentNullException("arguments must be not null");
    //    }

    //    var query = _context.Set<T>().AsNoTracking();

    //    foreach (var include in includes)
    //    {
    //        query = query.Include(include);
    //    }

    //    return query;
    //}

    //public async Task<IEnumerable<T>> GetListAsync(
    //    Expression<Func<T, bool>> criteria,
    //    List<Expression<Func<T, object>>> includes)
    //{
    //    if (criteria is null || includes is null)
    //    {
    //        throw new ArgumentNullException("arguments must be not null");
    //    }

    //    var query = _context.Set<T>().Where(criteria);

    //    foreach (var include in includes)
    //    {
    //        query = query.Include(include);
    //    }

    //    return query.AsNoTracking();
    //}

    //public async Task<T?> FindAsync(Expression<Func<T, bool>> criteria)
    //{
    //    if (criteria is null)
    //    {
    //        throw new ArgumentNullException("arguments must be not null");
    //    }

    //    return await _context.Set<T>()
    //        .AsNoTracking()
    //        .SingleOrDefaultAsync(criteria);
    //}

    //public async Task<T> FindAsync(
    //    Expression<Func<T, bool>> criteria,
    //    List<Expression<Func<T, object>>> includes)
    //{
    //    if (criteria is null || includes is null)
    //    {
    //        throw new ArgumentNullException("arguments must be not null");
    //    }

    //    var query = _context.Set<T>().Where(criteria);

    //    foreach (var include in includes)
    //    {
    //        query = query.Include(include);
    //    }

    //    return await query.AsNoTracking().SingleOrDefaultAsync();
    //}

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
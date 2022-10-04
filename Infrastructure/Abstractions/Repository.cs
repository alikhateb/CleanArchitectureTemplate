using System.Linq.Expressions;
using Domain.Abstractions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> conditionExpression)
    {
        return await _context.Set<T>()
            .Where(conditionExpression)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
    {
        var query = _context.Set<T>()
            .AsNoTracking();

        foreach (var navigationProperty in navigationProperties) query = query.Include(navigationProperty);

        return await query.ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> conditionExpression,
        params Expression<Func<T, object>>[] navigationProperties)
    {
        var query = _context.Set<T>()
            .Where(conditionExpression)
            .AsNoTracking();

        foreach (var navigationProperty in navigationProperties) query = query.Include(navigationProperty);

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> conditionExpression)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .SingleOrDefaultAsync(conditionExpression);
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> conditionExpression,
        params Expression<Func<T, object>>[] navigationProperties)
    {
        var query = _context.Set<T>()
            .Where(conditionExpression)
            .AsNoTracking();

        foreach (var navigationProperty in navigationProperties) query = query.Include(navigationProperty);

        return await query.SingleOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>()
            .AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>()
            .AddRangeAsync(entities);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>()
            .Update(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _context.Set<T>()
            .UpdateRange(entities);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>()
            .Remove(entity);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _context.Set<T>()
            .RemoveRange(entities);
    }
}
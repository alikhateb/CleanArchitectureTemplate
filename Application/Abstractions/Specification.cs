using Domain.Abstractions;
using System.Linq.Expressions;

namespace Application.Abstractions;

public class Specification<T> : ISpecification<T> where T : class
{
    public Specification()
    {
        Includes = new List<Expression<Func<T, object>>>();
    }

    public Expression<Func<T, bool>> Criteria { get; private set; }
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDescending { get; private set; }
    public List<Expression<Func<T, object>>> Includes { get; private set; }

    protected virtual void ApplyCriteria(Expression<Func<T, bool>> criteria)
        => Criteria = criteria;

    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderBy)
        => OrderBy = orderBy;

    protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescending)
        => OrderByDescending = orderByDescending;

    protected virtual void ApplyIncludes(Expression<Func<T, object>> include)
        => Includes.Add(include);
}
using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}

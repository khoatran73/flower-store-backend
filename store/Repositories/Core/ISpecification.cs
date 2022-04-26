using System.Linq.Expressions;

namespace store.Repositories.Core;

public interface ISpecification<T>
{
    List<string> IncludePaths { get; }

    List<Order<T>> Orders { get; }

    int Take { get; }

    int Skip { get; }

    bool IsPagingEnabled { get; }

    bool IsTracking { get; }

    bool IsSatisfiedBy(T candidate);

    ISpecification<T> And(ISpecification<T> other);

    ISpecification<T> Or(ISpecification<T> other);

    ISpecification<T> Not();

    Expression ToExpression();

    ISpecification<T> And(Expression<Func<T, bool>> other);

    ISpecification<T> Or(Expression<Func<T, bool>> other);

    ISpecification<T> Include(Expression<Func<T, object>> includeExpression);

    ISpecification<T> Include(IEnumerable<string> paths);

    ISpecification<T> Include(string path);

    ISpecification<T> Paginate(int skip, int take);

    ISpecification<T> OrderBy(Expression<Func<T, object>> order);

    ISpecification<T> OrderByDescending(Expression<Func<T, object>> order);
}
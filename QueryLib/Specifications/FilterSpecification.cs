using System.Linq.Expressions;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Specifications;

/// <inheritdoc />
public class FilterSpecification<T>(Expression<Func<T, bool>> criteria)
    : IFilterSpecification<T>
{
    /// <inheritdoc />
    public Expression<Func<T, bool>> Criteria { get; } = criteria;
}
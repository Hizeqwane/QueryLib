using System.Linq.Expressions;
using QueryLib.Models;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Specifications;

/// <inheritdoc />
public class SortSpecification<T>(Expression<Func<T, object>> criteria, SortingOrder order) 
    : ISortSpecification<T>
{
    /// <inheritdoc />
    public Expression<Func<T, object>> Criteria { get; } = criteria;

    /// <inheritdoc />
    public SortingOrder Order { get; } = order;
}